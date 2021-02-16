using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents an exchange rate for Belarus. 
    /// </summary>
    public class ExchangeRateBY : IExchangeRate
    {
        /// <summary>
        /// Represents target currency code.
        /// </summary>
        public string Cur_Abbreviation { get; set; }
        /// <summary>
        /// Represents an exchange rate value.
        /// </summary>
        public decimal Cur_OfficialRate { get; set; }

        public string GetHomeCurrency()
        {
            return "BYN";
        }

        public decimal GetRate()
        {
            return Cur_OfficialRate;
        }

        public string GetTargetCurrency()
        {
            return Cur_Abbreviation;
        }
    }
}
