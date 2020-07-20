using System;
using System.IO;
using Newtonsoft.Json;

namespace TikTokDownloader
{
    public class JsonHelper
    {
        public static T DeserializeFile<T>(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                
                    var archive = (T)serializer.Deserialize(file, typeof(T));
                    return archive;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static void SerializeFile(string path, object data)
        {
            var serialized = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, serialized);
        }
    }
}
