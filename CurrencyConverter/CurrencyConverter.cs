using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using CurrencyConverter.Services;
using CurrencyConverter.Models;
using System.Net;

namespace CurrencyConverter
{
    public class CurrencyConverter
    {
        private readonly IConfiguration config;
        private readonly IConversionService _conversionService;

        public CurrencyConverter(IConversionService conversionService, IConfiguration configuration)
        {
            config = configuration;
            _conversionService = conversionService;
        }


        [FunctionName("CurrencyConverter")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var trackingId = Guid.NewGuid().ToString();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation("Conversion request has been received, Payload={payload}, CorrelationId={correlationId}", requestBody, trackingId);
            IActionResult response = null;
            try
            {

                var requestModel = JsonConvert.DeserializeObject<CurrencyConversionRequest>(requestBody);
                var value = _conversionService.ConvertCurrency(requestModel);
                response = new OkObjectResult(value);
            }
            catch (Exception exception)
            {
                log.LogError("Currency conversion failed, CorrelationId={correlationId}, Reason={exception}", trackingId, exception);
                var errorMessage = new ErrorMessageDataModel() { Message = $"{exception.Message}, TrackingId={trackingId}" };
                response = new ContentResult() { StatusCode = (int)HttpStatusCode.InternalServerError, Content = JsonConvert.SerializeObject(errorMessage), ContentType = "application/json" };
            }

            return response;
        }
    }
}
