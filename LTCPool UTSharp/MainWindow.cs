using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Numerics;

namespace LTCPool_UTSharp
{
    public partial class MainWindow : Form
    {
        //The default path of the config file
        private const string defaultConfigPath = "settings.json";

        //The C# representation of data received from the litecoinpool.org API
        private Data apiData;

        //The C# representation of the config file data
        private Settings settings;

        //UNUSED: new path of the config file (Is it persistent? Where to store it?)
        private string configFilePath;

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
            //If the path of the new current config file isn't
            //persistent, then this should be a local variable
            configFilePath = settingsFDialog.FileName;

            //Load new settings and update
            //NOTES:
            //"update: true" is to set a parameter by name
            //I used it to explicitly say that we're updating too
            LoadSettings(configFilePath, update: true);
        }

        private void globalUpdater_Tick(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Load new settings and update
            //NOTES:
            //"update: true" is to set a parameter by name
            //I used it to explicitly say that we're updating too
            LoadSettings(defaultConfigPath, update: true);

            //Start update timer
            globalUpdater.Start();
        }

        /// <summary>
        /// Fetches new data and updates values inside the form
        /// </summary>
        private void UpdateValues()
        {
            //If settings weren't loaded correctly, don't update
            if (settings == null)
                return;

            //Fetch new API data
            Api.TryFetchApiData(settings.apiKey, out apiData);

            //Update Converter
            LtcConverter.Update(apiData.market);

            //Update visual data
            totWorkLbl.Text = GetTotalWork();
            TotEarnLbl.Text = GetTotalRevenue();
            HashSpeedLbl.Text = GetHashRate();
            excp24RewardsLbl.Text = GetExpected24HRevenue();
        }

        /// <summary>
        /// Loads a new set of settings
        /// </summary>
        /// <param name="path">Path to the settings</param>
        /// <param name="update">Should we update the values too?</param>
        private void LoadSettings(string path, bool update = false)
        {
            Settings newSettings;

            if(!Settings.TryFromFile(path, out newSettings))
            {
                Error("Error updating settings");
            }
            else
            {
                //Update settings only if successful
                settings = newSettings;

                if (update)
                {
                    //Display new values
                    UpdateValues();
                }
            }
        }

        /// <summary>
        /// Shows an error message to the user
        /// </summary>
        /// <param name="message">Error message to show</param>
        private void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Gets the total revenue generated
        /// </summary>
        private string GetTotalRevenue()
        {
            return LtcConverter.ToString(apiData.user.total_rewards, settings.currency, 2);
        }

        /// <summary>
        /// Gets the current hashes per second
        /// </summary>
        private string GetHashRate()
        {
            //hash_rate is in kilo hashes!
            //We need to scale it back to hashes to scale it
            return ScaleHash(apiData.user.hash_rate * 1000, settings.hashScale, 2) + "/s";
        }

        /// <summary>
        /// Gets the expected revenue for the next 24 hours
        /// </summary>
        private string GetExpected24HRevenue()
        {
            return LtcConverter.ToString(apiData.user.expected_24h_rewards, settings.currency, 2);
        }

        /// <summary>
        /// Gets the total hashes computed
        /// </summary>
        private string GetTotalWork()
        {
            return ScaleHash(apiData.user.total_work, HashScales.TH);
        }

        /// <summary>
        /// Scales a floating point hash count
        /// </summary>
        /// <param name="hash">Hash count</param>
        /// <param name="scale">Scale</param>
        /// <param name="decimalDigits">Decimal places to show. Default is 2</param>
        private string ScaleHash(double hash, HashScales scale, int decimalDigits = 2)
        {
            //Read documentation in HashScales.cs to understand why this division works
            hash /= (double)scale;
            return $"{hash.ToString("N" + decimalDigits)} {scale}";
        }

        /// <summary>
        /// Scales an integer hash count
        /// </summary>
        /// <param name="hash">Hash count</param>
        /// <param name="scale">Scale</param>
        private string ScaleHash(BigInteger hash, HashScales scale)
        {
            //Read documentation in HashScales.cs to understand why this division works
            hash /= (ulong)scale;
            return $"{hash} {scale}";
        }
    }
}
