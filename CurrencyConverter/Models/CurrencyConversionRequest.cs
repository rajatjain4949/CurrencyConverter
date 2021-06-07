using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Models
{
    public class CurrencyConversionRequest
    {
        public double Amount { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
    }
}
