using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Repositories
{
    public interface ICurrencyConversionRepository
    {
        public List<CurrencyConversion> GetAll();
    }
}
