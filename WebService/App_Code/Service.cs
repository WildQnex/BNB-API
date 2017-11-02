using Newtonsoft.Json.Linq;
using System.Net;
using System;
using System.IO;
using BNB_API;
using System.Runtime.Serialization;
using System.Threading;
using System.Collections.Generic;
using WebService;



// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private const string URL = "http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";
    

    public string GetAPI()
    {
        DataRes data = new DataRes();
        List<Thread> threads = new List<Thread>();
        WebClient webClient = new WebClient();
        webClient.Encoding = System.Text.Encoding.UTF8;
        Thread thread;
        try
        {
            string source = webClient.DownloadString(URL);
            dynamic obj = JArray.Parse(source);
            foreach (dynamic el in obj)
            {
                thread = new Thread(setLine);
                thread.Start(new Data(data, el));
                threads.Add(thread);
            }
            data.setCurTime(DateTime.Now.ToString());
            foreach (Thread thr in threads){
                thr.Join(new TimeSpan(0, 0, 2));
            }         
        }
        catch
        {
            data.addCurrency("Error. Check your internet connection");
        }
        var dcs = new DataContractSerializer(typeof(DataRes));
        using (MemoryStream stream = new MemoryStream())
        {
            dcs.WriteObject(stream, data);

            stream.Position = 0;
            TextReader reader = new StreamReader(stream);
            
            return reader.ReadToEnd();
        }
    }


    
    
    void setLine(Object o)
    {
        string title;
        Data dat = (Data) o;
        dynamic el = dat.getElement();
        title = el.Cur_Scale + " " + el.Cur_Name + " (" + el.Cur_Abbreviation + ") = "
                    + el.Cur_OfficialRate + " Рубля";
        dat.getDataRes().addCurrency(title);
        dat.getDataRes().setUpdateTime(el.Date.ToString());
    }


}

