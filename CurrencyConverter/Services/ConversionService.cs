using CurrencyConverter.Models;
using CurrencyConverter.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using CurrencyConverter.Helpers.Validators;
using CurrencyConverter.Helpers;
using System.Linq;

namespace CurrencyConverter.Services
{

    public class ConversionService : IConversionService
    {
        private readonly ICurrencyConversionRepository _currencyConversionRepository;

        public ConversionService(ICurrencyConversionRepository currencyConversionRepository)
        {
            _currencyConversionRepository = currencyConversionRepository;
        }

        public SuccessResponseDataModel ConvertCurrency(CurrencyConversionRequest request)
        {
            if (!Validator.ValidateAmount(request.Amount))
            {
                throw new ArgumentOutOfRangeException("Requested amount cannot be less than zero.");
            }

            var currencyExchange = _currencyConversionRepository.GetAll();

            if (!Validator.ValidateCurrency(request.FromCurrency, currencyExchange))
            {
                throw new ArgumentOutOfRangeException("Input Currency is not valid.");
            }

            if (!Validator.ValidateCurrency(request.ToCurrency, currencyExchange))
            {
                throw new ArgumentOutOfRangeException("Requested Currency is not valid.");
            }

            var currencyModel = new SuccessResponseDataModel()
            {
                Value = ConversionLogic(request, currencyExchange),
                Currency = request.ToCurrency
            };

            return currencyModel;
        }
        private double ConversionLogic(CurrencyConversionRequest conversionRequest, List<CurrencyConversion> currencies)
        {
            var sourceUSD = currencies.First(x => x.Name.Equals(conversionRequest.FromCurrency.ToUpper())).RateFromUsd;
            var targetUSD = currencies.First(x => x.Name.Equals(conversionRequest.ToCurrency.ToUpper())).RateFromUsd;
            return conversionRequest.Amount * targetUSD / sourceUSD;
        }
    }
}
