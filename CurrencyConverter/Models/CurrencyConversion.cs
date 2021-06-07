using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Models
{
    public class CurrencyConversion
    {
        public string Name { get; set; } = string.Empty;
        public double RateFromUsd { get; set; }
    }
}
