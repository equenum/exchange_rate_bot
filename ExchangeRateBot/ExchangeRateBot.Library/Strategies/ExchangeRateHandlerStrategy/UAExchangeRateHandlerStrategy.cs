using ExchangeRateBot.Library.Models;
using ExchangeRateBot.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateBot.Library.Strategies
{
    /// <summary>
    /// Represents UA exchange rate handler strategy.
    /// </summary>
    public class UAExchangeRateHandlerStrategy : IExchangeRateHandlerStrategy
    {
        public async Task<IExchangeRate> ExecuteAsync(IExchangeRateRequest request)
        {
            string url = $"https://api.privatbank.ua/p24api/exchange_rates?json&date={ request.Date.Day }.{ request.Date.Month }.{ request.Date.Year }";

            var resultExchangeRatesUA = await ApiHandler.GetAsync<ExchangeRateUAResults>(url);
            var resultExchangeRateUA = resultExchangeRatesUA.ExchangeRate.Where(x => x.GetTargetCurrency() == request.Currency).FirstOrDefault();
            
            return resultExchangeRateUA;
        }
    }
}
