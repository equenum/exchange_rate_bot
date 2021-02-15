using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    public class ExchangeRateUA : IExchangeRate
    {
        public string Currency { get; set; }
        public decimal SaleRateNB { get; set; }

        public decimal GetRate()
        {
            return SaleRateNB;
        }

        public string GetHomeCurrency()
        {
            return "UAH";
        }

        public string GetTargetCurrency()
        {
            return Currency;
        }
    }
}
