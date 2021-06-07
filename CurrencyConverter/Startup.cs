using CurrencyConverter.Repositories;
using CurrencyConverter.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(CurrencyConverter.Startup))]
namespace CurrencyConverter
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                           .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                           .AddEnvironmentVariables()
                           .Build();
            builder.Services.AddSingleton(config);
            builder.Services.AddSingleton<ICurrencyConversionRepository, CurrencyConversionRepository>();
            builder.Services.AddScoped<IConversionService, ConversionService>();          
        }       
    }
}
