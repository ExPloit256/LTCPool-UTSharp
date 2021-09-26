using Newtonsoft.Json;

using System.IO;
using System.Windows.Forms;

namespace LTCPool_UTSharp
{
    public class Settings
    {
        [JsonProperty] public readonly string apiKey;
        [JsonProperty] public readonly string currency;
        [JsonProperty] public readonly string hashScale;

        private Settings() { }

        public static bool TryFromFile(string path, out Settings settings)
        {
            if (File.Exists(path))
            {
                var fileData = File.ReadAllText(path);
                settings = JsonConvert.DeserializeObject<Settings>(fileData);
                return true;
            }
            else
            {
                settings = null;
                return false;
            }
        }
    }
}
