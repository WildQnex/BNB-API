using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BNB_API
{
    [DataContract]
    public class DataRes
    {
        [DataMember]
        private string curTime;
        [DataMember]
        private string updateTime;
        [DataMember]
        private List<string> currenciesList = new List<string>();

        public void addCurrency(string currency)
        {
            currenciesList.Add(currency);
        }

        public List<string> getCurrenciesList()
        {
            return currenciesList;
        }

        public string getCurTime()
        {
            return curTime;
        }

        public void setCurTime(string curTime)
        {
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
