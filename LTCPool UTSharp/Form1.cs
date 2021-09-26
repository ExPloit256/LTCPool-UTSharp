using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;

using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace LTCPool_UTSharp
{
    public partial class MainWindow : Form
    {
        //instance of our class where the functions are stored to
        Functions Functions = new Functions();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void importSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsFDialog.ShowDialog();
        }

        private void settingsFDialog_FileOk(object sender, CancelEventArgs e)
        {
            string settFName = settingsFDialog.FileName;

            string apiKey = Functions.parseConfigFile(settFName)[0].ToString();
            string currencyType = Functions.parseConfigFile(settFName)[1].ToString();
            string hashingScale = Functions.parseConfigFile(settFName)[2].ToString();

            globalUpdater.Start();
        }

        private void globalUpdater_Tick(object sender, EventArgs e)
        {

        }
    }

    public class Functions
    {
        // Global Declarations
        const string baseUrl = "https://www.litecoinpool.org/api?api_key=";
        dynamic data;
        // Global Declarations


        public string[] parseConfigFile(string path) 
        {
            string settFConetent = File.ReadAllText(path);

            string rawApiString = Regex.Match(settFConetent, "apikey:\\w+\\d+").ToString();
            string rawCurrencyString = Regex.Match(settFConetent, "currency:[^;]").ToString();
            string rawScaleString = Regex.Match(settFConetent, "hash_scale:\\w+").ToString();

            string apiKey = Regex.Replace(rawApiString, "apikey:", "").Trim();
            string currencyType = Regex.Replace(rawCurrencyString, "currency:", "").Trim();
            string hashingScale = Regex.Replace(rawScaleString, "hash_scale:", "").Trim();

            string[] settingsFileParams = { apiKey, currencyType, hashingScale };

            return settingsFileParams;
        }
        public bool fetchApiData()
        {
            if (!string.IsNullOrWhiteSpace(""))//settingsPage.apikeyTextbox.Text))
            {
                WebClient client = new WebClient();
                var apiDataChunk = client.DownloadString(baseUrl);//+ settingsPage.apikeyTextbox.Text);
                data = JsonConvert.DeserializeObject(apiDataChunk);
                return true;
            }
            else
            {
                MessageBox.Show("You must insert an API key!", "LTCPool UTSharp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public string getTotRevenue(string currency)
        {
            if (fetchApiData())
            {
                if (currency == "€")
                {
                    float total = data.user.total_rewards * data.market.ltc_eur;
                    return $"{total:n2}€";
                }
                else if (currency == "$")
                {
                    float total = data.user.total_rewards * data.market.ltc_usd;
                    return $"{total:n2}$";
                }
                else if (currency == "£")
                {
                    float total = data.user.total_rewards * data.market.ltc_gbp;
                    return $"{total:n2}£";
                }
                else if (currency == "Ł")
                {
                    float total = data.user.total_rewards;
                    return $"{total:n2}Ł";

                }

            }
            return null;
        }
        public string getHashrate(string selectedHashingScale)
        {
            if (selectedHashingScale == "H")
            {
                string hashRate = data.user.hash_rate + " H/s";
                return hashRate;
            }
            if (selectedHashingScale == "KH")
            {
                int numRate = Convert.ToInt32(data.user.hash_rate / 100);
                string hashRate = numRate.ToString() + " KH/s";
                return hashRate;
            }
            if (selectedHashingScale == "MH")
            {
                int numRate = Convert.ToInt32(data.user.hash_rate / 1000);
                string hashRate = numRate.ToString() + " MH/s";
                return hashRate;
            }
            if (selectedHashingScale == "GH")
            {
                int numRate = Convert.ToInt32(data.user.hash_rate / 10000);
                string hashRate = numRate.ToString() + " GH/s";
                return hashRate;
            }
            if (selectedHashingScale == "TH")
            {
                int numRate = Convert.ToInt32(data.user.hash_rate / 100000);
                string hashRate = numRate.ToString() + " TH/s";
                return hashRate;
            }
            return "";
        }
        public string getExpRev24(string currency)
        {
            if (fetchApiData())
            {
                if (currency == "€")
                {
                    float total = data.user.expected_24h_rewards * data.market.ltc_eur;
                    return $"{total:n2}€";
                }
                else if (currency == "$")
                {
                    float total = data.user.expected_24h_rewards * data.market.ltc_usd;
                    return $"{total:n2}$";
                }
                else if (currency == "£")
                {
                    float total = data.user.expected_24h_rewards * data.market.ltc_gbp;
                    return $"{total:n2}£";
                }
                else if (currency == "Ł")
                {
                    float total = data.user.expected_24h_rewards;
                    return $"{total:n2}Ł";

                }

            }
            return null;

        }
    }
}
