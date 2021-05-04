using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Models
{
    public class CurrencyConversion
    {
        public string Name { get; set; } = string.Empty;

        public decimal RateFromUsd { get; set; } = 0m;
    }
}
