using System.Windows.Forms;
using System.Net;

using Newtonsoft.Json;

namespace LTCPool_UTSharp
{
    public static class Api
    {
        // Global Declarations
        const string baseUrl = "https://www.litecoinpool.org/api?api_key=";
        
        public static bool TryFetchApiData(string apiKey, out Data apiData)
        {
            if(!string.IsNullOrWhiteSpace(apiKey))
            {
                if(apiKey.Length == 32)
                {
                    WebClient client = new WebClient();
                    var apiDataChunk = client.DownloadString(baseUrl + apiKey);
                    apiData = JsonConvert.DeserializeObject<Data>(apiDataChunk);
                    return true;
                }
                else
                {
                    MessageBox.Show("You must insert a valid API key!", "LTCPool UTSharp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    apiData = null;
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You must insert an API key!", "LTCPool UTSharp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                apiData = null;
                return false;
            }
        }
    }
}
