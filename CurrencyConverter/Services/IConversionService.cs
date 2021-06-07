using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Services
{
    public interface IConversionService
    {
        SuccessResponseDataModel ConvertCurrency(CurrencyConversionRequest request);
    }
}
