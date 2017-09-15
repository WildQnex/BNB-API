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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://www.nbrb.by/API/ExRates/Currencies";
            string source = new WebClient().DownloadString(url);
            dynamic obj = JArray.Parse(source);
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
        }
    }
}
