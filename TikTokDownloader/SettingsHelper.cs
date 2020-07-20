namespace TikTokDownloader
{
    public class Settings
    {
        public string DownloadFolder { get; set; }
        public string InitialDirectory { get; set; }
    }

    public class SettingsHelper
    {
        private const string path = "settings.json";

        public static void Save(Settings settings)
        {
            JsonHelper.SerializeFile(path, settings);
        }

        public static Settings Read()
        {
            return JsonHelper.DeserializeFile<Settings>(path);
        }
    }
}
