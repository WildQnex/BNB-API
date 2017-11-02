using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BNB_API;

namespace WebService
{
    public class Data
    {
        private DataRes dataRes;
       
        private dynamic element;

        public Data(DataRes dataRes, dynamic element)
        {
            this.dataRes = dataRes;
            this.element = element;
        }

        public DataRes getDataRes()
        {
            return this.dataRes;
        }

        public dynamic getElement()
        {
            return this.element;
        }
    }
}