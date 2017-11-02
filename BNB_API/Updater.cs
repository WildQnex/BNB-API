using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BNB_API
{
    public class Updater
    {
        public async static Task<DataRes> UpdateDataAsync()
        {
            return await Task.Run(() =>
            {
                ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();
                DataRes data = new DataRes();
                try
                {
                    string result = client.GetData();
                    MemoryStream stream = new MemoryStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(result);
                    writer.Flush();
                    stream.Position = 0;
                    var dcs = new DataContractSerializer(typeof(DataRes));
                    data = (DataRes)dcs.ReadObject(stream);
                }
                catch(Exception ex)
                {
                    data.addCurrency("Сервис занят");
                }
                return data;
            });

        }
    }
}
