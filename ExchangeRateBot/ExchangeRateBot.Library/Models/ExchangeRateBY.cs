using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    public class ExchangeRateBY : IExchangeRate
    {
        public string Cur_Abbreviation { get; set; }
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
