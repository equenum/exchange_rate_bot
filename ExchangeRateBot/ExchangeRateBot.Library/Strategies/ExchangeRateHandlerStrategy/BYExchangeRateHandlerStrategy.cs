using ExchangeRateBot.Library.Models;
using ExchangeRateBot.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateBot.Library.Strategies
{
    /// <summary>
    /// Represents BY exchange rate handler strategy.
    /// </summary>
    public class BYExchangeRateHandlerStrategy : IExchangeRateHandlerStrategy
    {
        public async Task<IExchangeRate> ExecuteAsync(IExchangeRateRequest request)
        {
            string url = $"https://www.nbrb.by/api/exrates/rates/{ request.Currency }?parammode=2&ondate={ request.Date.Year }-{ request.Date.Month }-{request.Date.Day}";

            var exchangeRateBY = await ApiHandler.GetAsync<ExchangeRateBY>(url);

            return exchangeRateBY;
        }
    }
}
