using CurrencyConverter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CurrencyConverter.Tests
{
    class CurrencyDataRequest
    {
        public static CurrencyConversionRequest Get_Valid_Sample_Request_Different_Currency()
        {
            var request = JsonConvert.DeserializeObject<List<CurrencyConversionRequest>>(File.ReadAllText(@"Sample_Valid_Request.json"));
            return request[0];
        }
        public static CurrencyConversionRequest Get_Valid_Sample_Request_Same_Currency()
        {
            var request = JsonConvert.DeserializeObject<List<CurrencyConversionRequest>>(File.ReadAllText(@"Sample_Valid_Request.json"));
            return request[1];
        }

        public static CurrencyConversionRequest Get_Invalid_Sample_Request_Invalid_Amount()
        {
            var request = JsonConvert.DeserializeObject<List<CurrencyConversionRequest>>(File.ReadAllText(@"Sample_Invalid_Request.json"));
            return request[0];
        }

        public static CurrencyConversionRequest Get_Invalid_Sample_Request_Invalid_Currency()
        {
            var request = JsonConvert.DeserializeObject<List<CurrencyConversionRequest>>(File.ReadAllText(@"Sample_Invalid_Request.json"));
            return request[1];
        }


    }
}
