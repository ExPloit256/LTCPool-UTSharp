using Newtonsoft.Json;

using System.IO;

namespace LTCPool_UTSharp
{
    //NOTES: Using readonly without [JsonProperty] attribute doesn't let JsonConvert deserialize data

    //Our programs settings
    public class Settings
    {
        [JsonProperty] public readonly string apiKey;
        [JsonProperty] public readonly Currencies currency;
        [JsonProperty] public readonly HashScales hashScale;
        [JsonProperty] public readonly int hashDecimals;
        [JsonProperty] public readonly int currencyDecimals;

        //Disallow instance creation
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
