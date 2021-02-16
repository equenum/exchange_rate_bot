using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents an exchange rate for Ukraine. 
    /// </summary>
    public class ExchangeRateUA : IExchangeRate
    {
        /// <summary>
        /// Represents target currency code.
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// Represents an exchange rate value.
        /// </summary>
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
