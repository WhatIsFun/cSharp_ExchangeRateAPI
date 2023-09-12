using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ExchangeRateAPI
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Exchange Rate Service\n\n\r\n" +
                "E.g:\n" +
                "Currency Code  Currency Name\n" +
                "OMR            Omani Rial\n" +
                "AED            UAE Dirham\n" +
                "USD            United States Dollar\n" +
                "EUR            Euro\n");
            Console.WriteLine("Enter the base currency: ");
            string Base = Console.ReadLine();
            Console.WriteLine("Enter the exchange currency: ");
            string exchangeTo = Console.ReadLine();
            ExchangeRateService exchangeRateService = new ExchangeRateService();
            ExchangeRateData exchangeRates = await exchangeRateService.GetExchangeRatesAsync(Base, exchangeTo);

            if (exchangeRates != null)
            {
                Console.WriteLine($"Base Currency: {exchangeRates.base_code}");
                Console.WriteLine($"Target Currency: {exchangeRates.target_code}");
                Console.WriteLine("Exchange Rates:");
                foreach (var conversion_rate in exchangeRates.conversion_rate)
                {
                    Console.Write($"{conversion_rate}");
                }
            }
        }
    }
}