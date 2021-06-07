using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConverter.Helpers.Validators
{
    public static class Validator //: IValidator
    {
        public static bool ValidateAmount(double amount)
        {
            if (amount < 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateCurrency(string currency, List<CurrencyConversion> currencies)
        {
            if (!currencies.Any(x => x.Name.Equals(currency.ToUpper())))
            {
                return false;
            }
            return true;
        }
    }
}
