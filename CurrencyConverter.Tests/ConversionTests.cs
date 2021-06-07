using CurrencyConverter.Repositories;
using CurrencyConverter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CurrencyConverter.Tests
{
    [TestClass]
    public class ConversionTests
    {
        private readonly IConversionService _conversionService;

        public ConversionTests()
        {
            _conversionService = new ConversionService(new CurrencyConversionRepository());
        }
        [TestMethod]
        public void Check_Amount_INR_to_USD_Valid_Request()
        {
            var request = CurrencyDataRequest.Get_Valid_Sample_Request_Different_Currency();
            var x = _conversionService.ConvertCurrency(request);
            Assert.AreEqual(2, x.Value);
        }

        [TestMethod]
        public void Check_Currency_INR_to_USD_Valid_Request()
        {
            var request = CurrencyDataRequest.Get_Valid_Sample_Request_Different_Currency();
            var x = _conversionService.ConvertCurrency(request);
            Assert.AreEqual(request.ToCurrency, x.Currency);
        }

        [TestMethod]
        public void Check_Amount_USD_to_USD_Valid_Request()
        {
            var request = CurrencyDataRequest.Get_Valid_Sample_Request_Same_Currency();
            var x = _conversionService.ConvertCurrency(request);
            Assert.AreEqual(request.Amount, x.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Check_Invalid_Amount_Throws_Exception()
        {
            var request = CurrencyDataRequest.Get_Invalid_Sample_Request_Invalid_Amount();
            var x = _conversionService.ConvertCurrency(request);
        }

        //same to same
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Check_Invalid_Currency_Throws_Exception()
        {
            var request = CurrencyDataRequest.Get_Invalid_Sample_Request_Invalid_Currency();
            var x = _conversionService.ConvertCurrency(request);
        }
    }
}
