using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using TikTokDownloader.TikTok;

namespace TikTokDownloader
{
	class MainViewModel : ObservableObject
    {
		private HttpClient client;
		public MainViewModel()
		{
			client = new HttpClient();
			//client.DefaultRequestHeaders.Host = "v16-web.tiktok.com";
			//client.DefaultRequestHeaders.Referrer = new Uri("https://www.tiktok.com/");

            DownloadFromHarCommand = new AsyncCommand(DownloadFromHarAsync);
			ChooseFolderCommand = new Command(ChooseFolder);
			OpenJsonCommand = new AsyncCommand(OpenAndDownloadJsonAsync);
			settings = SettingsHelper.Read();
			if(settings == null)
			{
				settings = new Settings
				{
					DownloadFolder = KnownFolders.Downloads.Path,
					InitialDirectory = KnownFolders.Downloads.Path
				};
				SettingsHelper.Save(settings);
			}
		}
		
		private void CatchException(Exception ex, string url, string fileName = "logs.txt")
		{
			File.AppendAllText(fileName, Environment.NewLine);
			File.AppendAllText(fileName, DateTime.Now.ToString());
			File.AppendAllText(fileName, Environment.NewLine);
			File.AppendAllText(fileName, url);
			File.AppendAllText(fileName, Environment.NewLine);
			File.AppendAllText(fileName, ex.ToString());
			ErrorMessage = ex.ToString();
		}

		private void LogToFile(string message, string fileName = "logs.txt")
        {
			File.AppendAllText(fileName, Environment.NewLine);
			File.AppendAllText(fileName, message);
			ErrorMessage = message;
		}

		private string pastedText = "";
		public string PastedText
		{
			get { return pastedText; }
			set { SetProperty(ref pastedText, value); }
		}


		private bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}


		private string progress;
		public string Progress
		{
			get { return progress; }
			set { SetProperty(ref progress, value); }
		}


        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public ICommand OpenJsonCommand { get; }

		public ICommand ChooseFolderCommand { get; }

		public ICommand DownloadFromHarCommand { get; }

		private Settings settings;
		
		private void ChooseFolder()
		{
			CommonOpenFileDialog dialog = new CommonOpenFileDialog();
			dialog.InitialDirectory = settings.DownloadFolder;
			dialog.IsFolderPicker = true;
			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
			{
				settings.DownloadFolder = dialog.FileName;
				SettingsHelper.Save(settings);
			}
		}

		private async Task DownloadVideoAsync(string url, string videoName)
		{
			string filePath = Path.Combine(settings.DownloadFolder, videoName + ".mp4");
			if (File.Exists(filePath))
            {
				return;
            }
			var response = await client.GetAsync(url);
			using (var fs = new FileStream(filePath, FileMode.Create))
			{
				await response.Content.CopyToAsync(fs);
			}
		}

		private static string RemoveForbiddenChars(string videoName)
		{
			foreach (var ch in Path.GetInvalidPathChars())
			{
				videoName = videoName.Replace(ch, ' ');
			}
			foreach (var ch in Path.GetInvalidFileNameChars())
			{
				videoName = videoName.Replace(ch, ' ');
			}

			return videoName;
		}

		private async Task DownloadFromHarAsync()
		{
			IsBusy = true;

            try
            {
                var favs = GetJsonFromHar();
                if (favs == null)
                {
                    IsBusy = false;
                    return;
                }
                var filename = $"videos ({DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}).json";
                var path = Path.Combine(settings.DownloadFolder, filename);
                JsonHelper.SerializeFile(path, favs);
				favs.Reverse();
				await DownloadListAsync(favs);
            }
            catch (Exception ex)
            {
				ErrorMessage = ex.ToString();
				CatchException(ex, nameof(DownloadFromHarAsync));
            }

			IsBusy = false;
		}



		private async Task OpenAndDownloadJsonAsync()
		{
			IsBusy = true;

            try
            {
                var favs = DeserializeFile<List<FavoriteItem>>();
                if (favs == null)
                {
                    IsBusy = false;
                    return;
                }
				favs.Reverse();
                await DownloadListAsync(favs);
            }
            catch (Exception ex)
            {
				CatchException(ex, nameof(OpenAndDownloadJsonAsync));
            }
		
			IsBusy = false;
		}

		private List<FavoriteItem> GetJsonFromHar()
        {
			var archive = DeserializeFile<HarArchive>();

			if (archive == null) return null;

			var requests = archive.Log.Entries
				.Where(x => x.Request.Url.ToString().Contains("https://m.tiktok.com/api/item_list"));

			var favList = new List<FavoriteItem>();
			
			foreach (var req in requests)
			{
                try
                {
					string json = "";
					if(req.Response.Content.MimeType == "application/json")
                    {
                        if (req.Response.Content.Text.Contains('{'))
                        {
							json = req.Response.Content.Text;
						}
                        else
                        {
							var data = Convert.FromBase64String(req.Response.Content.Text);
							json = System.Text.Encoding.UTF8.GetString(data);
						}
					}
					else if (req.Response.Content.MimeType == "base64")
                    {
						var data = Convert.FromBase64String(req.Response.Content.Text);
						json = System.Text.Encoding.UTF8.GetString(data);
					}
                    else { }
                    var favorites = JsonConvert.DeserializeObject<Favorites>(json);
                    foreach (var fav in favorites.Items)
                    {
						fav.Headers.AddRange(req.Request.Headers.Where(x=>!x.Name.StartsWith(":")));
                        favList.Add(fav);
                    }
                }
                catch (Exception ex)
                {
					LogToFile(ex.ToString());
				}
			}

			return favList;
		}

		private async Task DownloadListAsync(List<FavoriteItem> favs)
		{
			client = new HttpClient();
			foreach (var header in favs.FirstOrDefault().Headers)
            {
				client.DefaultRequestHeaders.Add(header.Name, header.Value);
            }

			counter = 1;
			total = favs.Count;
			Progress = $"{counter}/{total}";
			foreach (var partition in Partition<FavoriteItem>(favs, 4))
			{
				await Task.WhenAll(partition.Select(x => DownloadWrapper(x)));
			}
		}

		private int counter = 1;
		private int total = 1;
		private static SemaphoreSlim semaphore = new SemaphoreSlim(1,1);

		private async Task DownloadWrapper(FavoriteItem fav)
        {
			var videoName = $"{fav.Author.UniqueId} - {fav.Desc}";
			videoName = RemoveForbiddenChars(videoName);
            try
            {
                await DownloadVideoAsync(fav.Video.DownloadAddr.ToString(), videoName);
            }
			catch (Exception ex)
			{
				CatchException(ex, fav.Id, "logsJson.txt");
			}
			
			semaphore.Wait();
			counter++;
			Progress = $"{counter}/{total}";
			semaphore.Release();
		}

		private T DeserializeFile<T>()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = settings.DownloadFolder;
			if (openFileDialog.ShowDialog() == true)
			{
				return JsonHelper.DeserializeFile<T>(openFileDialog.FileName);
			}
			return default(T);
		}

		public IEnumerable<IEnumerable<T>> Partition<T>(IEnumerable<T> source, int size)
		{
			var partition = new List<T>(size);
			var counter = 0;

			using (var enumerator = source.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					partition.Add(enumerator.Current);
					counter++;
					if (counter % size == 0)
					{
						yield return partition.ToList();
						partition.Clear();
						counter = 0;
					}
				}

				if (counter != 0)
					yield return partition;
			}
		}
	}
}
