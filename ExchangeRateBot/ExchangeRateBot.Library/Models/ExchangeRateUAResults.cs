using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    public class ExchangeRateUAResults
    {
        public DateTime Date { get; set; }
        public List<ExchangeRateUA> ExchangeRate { get; set; }
    }
}
