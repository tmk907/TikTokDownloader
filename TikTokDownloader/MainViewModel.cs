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
		private readonly HttpClient client;
		public MainViewModel()
		{
			client = new HttpClient();

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
			if (File.Exists(filePath)) return;
			
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

			var favs = GetJsonFromHar();
			if (favs == null) return;
			JsonHelper.SerializeFile(settings.DownloadFolder, favs);
			await DownloadListAsync(favs);

			IsBusy = false;
		}

		private async Task OpenAndDownloadJsonAsync()
		{
			IsBusy = true;

			var favs = DeserializeFile<List<FavoriteItem>>();
			if (favs == null) return;
			await DownloadListAsync(favs);
		
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
				var data = Convert.FromBase64String(req.Response.Content.Text);
				var json = System.Text.Encoding.UTF8.GetString(data);
				var favorites = JsonConvert.DeserializeObject<Favorites>(json);
				foreach (var fav in favorites.Items)
				{
					favList.Add(fav);
				}
			}

			return favList;
		}

		private async Task DownloadListAsync(List<FavoriteItem> favs)
		{
			counter = 1;
			total = favs.Count;
			Progress = $"{counter}/{total}";
			foreach (var partition in Partition<FavoriteItem>(favs, 10))
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
