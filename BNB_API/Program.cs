using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BNB_API
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBNB());

        }
    }

    public class Updater{
        public async static Task<DataRes> UpdateDataAsync(){
            return await Task.Run(() =>
            {
                ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();
                DataRes data = new DataRes();
                try
                {
                string result = client.GetAPI();
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(result);
                writer.Flush();
                stream.Position = 0;
                var dcs = new DataContractSerializer(typeof(DataRes));
                data = (DataRes)dcs.ReadObject(stream);
                }
                catch
                {
                    data.addCurrency("Сервис занят");
                }
                return data;
            });
            
        }
    }


}
