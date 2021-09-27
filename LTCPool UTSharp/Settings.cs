using Newtonsoft.Json;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
                return Validate(settings);
            }
            else
            {
                settings = null;
                return false;
            }
        }

        private static bool Validate(Settings settings)
        {
            if(string.IsNullOrWhiteSpace(settings.apiKey))
            {
                Error("Please insert an API key");
                return false;
            }

            if(settings.apiKey.Length != 32)
            {
                Error("Invalid api key.\nPlease, get one from https://www.litecoinpool.org/account then go to settings.json");
                return false;
            }

            if (!Enum.IsDefined(typeof(Currencies), settings.currency))
            {
                Error("Invalid currency");
                return false;
            }

            if (!Enum.IsDefined(typeof(HashScales), settings.hashScale))
            {
                Error("Invalid hash scale");
                return false;
            }

            if(settings.hashDecimals < 0)
            {
                Error("Hash decimals should be a positive number");
                return false;
            }
             
            if(settings.currencyDecimals < 0)
            {
                Error("Currency decimals should be a positive number");
                return false;
            }

            return true;
        }

        //Copied from MainWindow
        //Should we make an "error api"?
        private static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
