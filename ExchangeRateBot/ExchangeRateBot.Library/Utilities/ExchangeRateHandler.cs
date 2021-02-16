﻿using ExchangeRateBot.Library.Models;
using ExchangeRateBot.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents an exchange rate handler.
    /// </summary>
    public class ExchangeRateHandler : IExchangeRateHandler
    {
        private string _currency;
        private string _country;
        private DateTime _date;

        public async Task<IExchangeRate> LoadExchangeRate()
        {
            string url;

            switch (_country)
            {
                case "BY":
                    url = $"https://www.nbrb.by/api/exrates/rates/{ _currency }?parammode=2&ondate={ _date.Year }-{ _date.Month }-{_date.Day}";
                    var exchangeRateBY = await Get<ExchangeRateBY>(url);
                    return exchangeRateBY;
                case "UA":
                    url = $"https://api.privatbank.ua/p24api/exchange_rates?json&date={ _date.Day }.{ _date.Month }.{ _date.Year }";
                    var resultExchangeRatesUA = await Get<ExchangeRateUAResults>(url);
                    var resultExchangeRateUA = resultExchangeRatesUA.ExchangeRate.Where(x => x.GetTargetCurrency() == _currency).FirstOrDefault();
                    return resultExchangeRateUA;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            async Task<T> Get<T>(string apiUrl)
            {
                using (HttpResponseMessage response = await ApiHandler.ApiClient.GetAsync(apiUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        T exchangeRate = await response.Content.ReadAsAsync<T>();

                        return exchangeRate;
                    }
                    else
                    {
                        Console.WriteLine(response.ReasonPhrase);

                        return default;
                    }
                }
            }
        }

        public void SetNewInput(string inputMessage)
        {
            var message = inputMessage.Split(' ');

            _currency = message[2];
            _date = DateTime.ParseExact(
                message[3], "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture
                );
            _country = message[4];
        }
    }
}
