using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;


namespace BNB_API
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBNB());

        }
    }

    static class Updater{
        public static Data UpdateData(){
            Data data = new Data();
            string url = "http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";
            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            try {
                string source = webClient.DownloadString(url);
                dynamic obj = JArray.Parse(source);
                string title;
                foreach (dynamic el in obj)
                {
                    title = el.Cur_Scale + " " + el.Cur_Name + " (" + el.Cur_Abbreviation + ") = "
                        + el.Cur_OfficialRate + " Рубля";
                    data.addCurrency(title);
                    data.setUpdateTime(el.Date.ToString());
                }
                data.setCurTime(DateTime.Now.ToString());
            } catch {
                data.addCurrency("Error. Check your internet connection");
            }
            return data;
        }
    }

    class Data
    {
        private string curTime;
        private string updateTime;
        private List<string> currenciesList = new List<string>();

        public void addCurrency(string currency){
            currenciesList.Add(currency);
        }

        public List<string> getCurrenciesList(){
            return currenciesList;
        }

        public string getCurTime(){
            return curTime;
        }

        public void setCurTime(string curTime){
            this.curTime = curTime;
        }

        public string getUpdateTime()
        {
            return updateTime;
        }

        public void setUpdateTime(string updateTime)
        {
            this.updateTime = updateTime;
        }

    }
}
