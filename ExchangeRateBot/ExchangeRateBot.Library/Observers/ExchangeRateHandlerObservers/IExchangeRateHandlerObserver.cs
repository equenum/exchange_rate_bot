using ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers.ExchangeRateObservers
{
    /// <summary>
    /// Represents an exchange rate handler interface.
    /// </summary>
    public interface IExchangeRateHandlerObserver
    {
        /// <summary>
        /// Updates a subject under observation.
        /// </summary>
        /// <param name="subject">Exchange rate handler.</param>
        void Update(IExchangeRateHandlerSubject subject);
    }
}
