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
    public partial class MainWindow : Form
    {
        Form2 SettingsWindow = new Form2();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {   

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow.Show();
        }

        private void settingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SettingsWindow.Show();
        }
    }
}
