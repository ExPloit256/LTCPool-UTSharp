﻿using System;
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
        private const string defaultConfigPath = "settings.txt";

        //instance of our class where the functions are stored to
        Functions Functions = new Functions();

        Settings settings;

        // Local Variables
        public string configFilePath;

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
            configFilePath = settingsFDialog.FileName;
        }

        private void globalUpdater_Tick(object sender, EventArgs e)
        {
            totWorkLbl.Text = Functions.getTotWork();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            settings = Functions.parseConfigFile(defaultConfigPath);
            Functions.fetchApiData(settings.apiKey);
            totWorkLbl.Text = Functions.getTotWork();
        }
    }

    public class Settings
    {
        public string apiKey;
        public string currency;
        public string hashScale;
    }

    public class Functions
    {
        // Global Declarations
        const string baseUrl = "https://www.litecoinpool.org/api?api_key=";
        dynamic data;

        public static Settings parseConfigFile(string path)
        {
            if(File.Exists(path))
            {
                var fileData = File.ReadAllText(path);
                var settings = JsonConvert.DeserializeObject<Settings>(fileData);
                return settings;
            }
            else
            {
                return null;
            }
        }

        public bool fetchApiData(string apiKey)
        {
            if ((!string.IsNullOrWhiteSpace(apiKey)) && apiKey.Length == 32)
            {
                WebClient client = new WebClient();
                var apiDataChunk = client.DownloadString(baseUrl + apiKey);
                data = JsonConvert.DeserializeObject(apiDataChunk);
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("You must insert an API key!", "LTCPool UTSharp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (apiKey.Length == 32)
            {
                MessageBox.Show("You must insert a valid API key!", "LTCPool UTSharp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return false;
        }

        public string getTotRevenue(string currency)
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
            else if (currency == "₿")
            {
                float total = data.user.total_rewards;
                return $"{total:n2}₿";
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
            return null;
        }

        public string getTotWork() { return Convert.ToUInt64(data.user.total_work / 1_000_000_000_000).ToString() + " TH"; }
    }
}
