using System;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents a validated exchange rate request interface.
    /// </summary>
    public interface IExchangeRateRequest
    {
        /// <summary>
        /// Represents target country.
        /// </summary>
        string Country { get; set; }
        /// <summary>
        /// Represents target currency.
        /// </summary>
        string Currency { get; set; }
        /// <summary>
        /// Represents target date.
        /// </summary>
        DateTime Date { get; set; }
    }
}