using ExchangeRateBot.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateBot.Library.Strategies
{
    /// <summary>
    /// Represents an exchange rate handler strategy interface.
    /// </summary>
    public interface IExchangeRateHandlerStrategy
    {
        /// <summary>
        /// Execites the strategy asynchronously.
        /// </summary>
        /// <param name="request">Target exchange rate request.</param>
        /// <returns>Target exchange rate.</returns>
        Task<IExchangeRate> ExecuteAsync(IExchangeRateRequest request);
    }
}
