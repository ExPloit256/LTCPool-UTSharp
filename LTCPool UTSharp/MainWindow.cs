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

    public class Functions
    {
        // Global Declarations
        const string baseUrl = "https://www.litecoinpool.org/api?api_key=";
        
        public Data apiData;

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
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You must insert an API key!", "LTCPool UTSharp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public string getTotRevenue(string currency)
        {
            if (currency == "€")
            {
                var total = apiData.user.total_rewards * apiData.market.ltc_eur;
                return $"{total:n2}€";
            }
            else if (currency == "$")
            {
                var total = apiData.user.total_rewards * apiData.market.ltc_usd;
                return $"{total:n2}$";
            }
            else if (currency == "£")
            {
                var total = apiData.user.total_rewards * apiData.market.ltc_gbp;
                return $"{total:n2}£";
            }
            else if (currency == "Ł")
            {
                var total = apiData.user.total_rewards;
                return $"{total:n2}Ł";
            }
            else if (currency == "₿")
            {
                var total = apiData.user.total_rewards;
                return $"{total:n2}₿";
            }
            return null;
        }

        public string getHashrate(string selectedHashingScale)
        {
            if (selectedHashingScale == "H")
            {
                string hashRate = apiData.user.hash_rate + " H/s";
                return hashRate;
            }
            if (selectedHashingScale == "KH")
            {
                int numRate = Convert.ToInt32(apiData.user.hash_rate / 100);
                string hashRate = numRate.ToString() + " KH/s";
                return hashRate;
            }
            if (selectedHashingScale == "MH")
            {
                int numRate = Convert.ToInt32(apiData.user.hash_rate / 1000);
                string hashRate = numRate.ToString() + " MH/s";
                return hashRate;
            }
            if (selectedHashingScale == "GH")
            {
                int numRate = Convert.ToInt32(apiData.user.hash_rate / 10000);
                string hashRate = numRate.ToString() + " GH/s";
                return hashRate;
            }
            if (selectedHashingScale == "TH")
            {
                int numRate = Convert.ToInt32(apiData.user.hash_rate / 100000);
                string hashRate = numRate.ToString() + " TH/s";
                return hashRate;
            }
            return "";
        }

        public string getExpRev24(string currency)
        {
            if (currency == "€")
            {
                var total = apiData.user.expected_24h_rewards * apiData.market.ltc_eur;
                return $"{total:n2}€";
            }
            else if (currency == "$")
            {
                var total = apiData.user.expected_24h_rewards * apiData.market.ltc_usd;
                return $"{total:n2}$";
            }
            else if (currency == "£")
            {
                var total = apiData.user.expected_24h_rewards * apiData.market.ltc_gbp;
                return $"{total:n2}£";
            }
            else if (currency == "Ł")
            {
                var total = apiData.user.expected_24h_rewards;
                return $"{total:n2}Ł";

            }
            return null;
        }

        public string getTotWork() { return Convert.ToUInt64(apiData.user.total_work / 1_000_000_000_000).ToString() + " TH"; }
    }
}
