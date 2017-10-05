using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BNB_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";
            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string source;
            dynamic obj;
            try {
                source = webClient.DownloadString(url);
                obj = JArray.Parse(source);
                string title;
                foreach (dynamic el in obj)
                {
                    title = "";
                    foreach (string tit in el)
                    {
                        title = title + tit + "  |  ";
                    }
                    Box.Items.Add(title);
                }
            } catch {
                Box.Items.Add("Error. Check your internet connection");
            }
        }

      
    }
}
