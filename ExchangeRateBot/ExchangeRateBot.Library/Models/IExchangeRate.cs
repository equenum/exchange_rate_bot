using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents an interface for an exchange rate.
    /// </summary>
    public interface IExchangeRate
    {
        /// <summary>
        /// Gets the exchange rate.
        /// </summary>
        /// <returns>Exchange rate decimal value.</returns>
        decimal GetRate();
        /// <summary>
        /// Gets domestic currency code.
        /// </summary>
        /// <returns>Domestic currency code.</returns>
        string GetHomeCurrency();
        /// <summary>
        /// Gets target currency code.
        /// </summary>
        /// <returns>Target currency code.</returns>
        string GetTargetCurrency();
    }
}
