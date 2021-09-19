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

namespace LTCPool_UTSharp
{
    public partial class MainWindow : Form
    {
        const string baseUrl = "https://www.litecoinpool.org/api?api_key=";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        async Task fetchAPIDataAsync(string baseUrl, string apiKey)
        {
            if (apikeyTextbox.Text != string.Empty)
            {
                string apiKey = apikeyTextbox.Text;
                using (var httpClient = new HttpClient())
                {
                    var responseString = await httpClient.GetStringAsync(baseUrl + apiKey);
                }
            }

        }
    }
}
