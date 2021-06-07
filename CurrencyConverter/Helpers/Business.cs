using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConverter.Helpers
{
    public static class Business
    {
        public static double ConversionLogic(CurrencyConversionRequest conversionRequest, List<CurrencyConversion> currencies)
        {
            var sourceUSD = currencies.First(x => x.Name.Equals(conversionRequest.FromCurrency.ToUpper())).RateFromUsd;
            var targetUSD = currencies.First(x => x.Name.Equals(conversionRequest.ToCurrency.ToUpper())).RateFromUsd;
            return conversionRequest.Amount * targetUSD / sourceUSD;
        }
    }
}
