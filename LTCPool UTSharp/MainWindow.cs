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
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Numerics;

namespace LTCPool_UTSharp
{
    public partial class MainWindow : Form
    {
        private const string defaultConfigPath = "settings.txt";

        private Data apiData;

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
            UpdateValues();
            Text = "Updated";
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Settings.TryFromFile(defaultConfigPath, out settings);

            UpdateValues();
            globalUpdater.Start();
        }

        void UpdateValues()
        {
            //Fetch new API data
            Api.TryFetchApiData(settings.apiKey, out apiData);

            //Update Converter
            LtcConverter.Update(apiData.market);

            totWorkLbl.Text = GetTotalWork();
            TotEarnLbl.Text = GetTotalRevenue();
            HashSpeedLbl.Text = GetHashRate();
            excp24RewardsLbl.Text = GetExpected24HRevenue();
        }

        public string GetTotalRevenue()
        {
            return LtcConverter.ToString(apiData.user.total_rewards, settings.currency, 2);
        }

        public string GetHashRate()
        {
            return ScaleHash(apiData.user.hash_rate * 1000, settings.hashScale, 2) + "/s";
        }

        public string GetExpected24HRevenue()
        {
            return LtcConverter.ToString(apiData.user.expected_24h_rewards, settings.currency, 2);
        }

        public string GetTotalWork()
        {
            return ScaleHash(apiData.user.total_work, HashScales.TH);
        }

        private string ScaleHash(double hash, HashScales scale, int decimalDigits = 2)
        {
            hash /= (double)scale;
            return $"{hash.ToString("N" + decimalDigits)} {scale}";
        }

        private string ScaleHash(BigInteger hash, HashScales scale)
        {
            hash /= (ulong)scale;
            return $"{hash} {scale}";
        }

    }
}
