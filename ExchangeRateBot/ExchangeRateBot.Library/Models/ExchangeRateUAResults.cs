using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents an Ukraine exchange rate JSON-parsing result.
    /// </summary>
    public class ExchangeRateUAResults
    {
        /// <summary>
        /// Represent a list of available currency exchange rates.
        /// </summary>
        public List<ExchangeRateUA> ExchangeRate { get; set; }
    }
}
