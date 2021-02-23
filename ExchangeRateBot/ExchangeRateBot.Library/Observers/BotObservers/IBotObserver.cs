using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    /// <summary>
    /// Represents a bot observer interface.
    /// </summary>
    public interface IBotObserver
    {
        /// <summary>
        /// Updates a subject under observation.
        /// </summary>
        /// <param name="subject">Bot.</param>
        void Update(IBot subject);
    }
}
