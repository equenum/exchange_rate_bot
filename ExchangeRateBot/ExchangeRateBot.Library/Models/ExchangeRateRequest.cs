using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents a validated exchange rate request.
    /// </summary>
    public class ExchangeRateRequest : IExchangeRateRequest
    {
        public string Currency { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
    }
}
