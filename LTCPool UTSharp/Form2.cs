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
using Newtonsoft.Json;

namespace LTCPool_UTSharp
{
    public partial class Form2 : Form
    {
        const string baseUrl = "https://www.litecoinpool.org/api?api_key=";
        readonly WebClient client;
        dynamic data;

        public Form2()
        {
            InitializeComponent();
            client = new WebClient();
            data = null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        void fetchApiData()
        {
            if (!string.IsNullOrWhiteSpace(apikeyTextbox.Text))
            {
                var apiDataChunk = client.DownloadString(baseUrl + apikeyTextbox.Text);
                data = JsonConvert.DeserializeObject(apiDataChunk);
            }
        }

        string displayTotRevenue(string currency) 
        {
            fetchApiData();
            if (currency == "€")
            {
                float total = data.user.total_rewards * data.market.ltc_eur;
                return $"{total:n2}€";
            }
            else if(currency == "$")
            {
                float total = data.user.total_rewards * data.market.ltc_usd;
                return $"{total:n2}$";
            }
            else if (currency == "£")
            {
                float total = data.user.total_rewards * data.market.ltc_gbp;
                return $"{total:n2}£";
            }
            return null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.ForeColor == Color.DarkRed)
            {
                apikeyTextbox.UseSystemPasswordChar = true;
                checkBox1.ForeColor = Color.Green;
            }
            else if (checkBox1.ForeColor == Color.Green)
            {
                apikeyTextbox.UseSystemPasswordChar = false;
                checkBox1.ForeColor = Color.DarkRed;
            }

        }
    }
}
