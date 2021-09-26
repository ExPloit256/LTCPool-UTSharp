﻿using System.Windows.Forms;
using System.Net;

using Newtonsoft.Json;

namespace LTCPool_UTSharp
{
    public static class Api
    {
        //Base API url
        private const string baseUrl = "https://www.litecoinpool.org/api?api_key=";

        //WebClient
        private static readonly WebClient client;

        static Api()
        {
            //Webclients are expensive, so we create it once in the static contructor
            client = new WebClient();
        }

        public static bool TryFetchApiData(string apiKey, out Data apiData)
        {
            if(!string.IsNullOrWhiteSpace(apiKey))
            {
                if(apiKey.Length == 32)
                {
                    var apiDataChunk = client.DownloadString(baseUrl + apiKey);
                    apiData = JsonConvert.DeserializeObject<Data>(apiDataChunk);
                    return true;
                }
                else
                {
                    Error("You must insert a valid API key!");
                    apiData = null;
                    return false;
                }
            }
            else
            {
                Error("You must insert an API key!");
                apiData = null;
                return false;
            }
        }

        //Copied from MainWindow
        //Should we make an "error api"?
        private static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
