using ExchangeRateBot.Library.Models;
using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers
{
    /// <summary>
    /// Represents a exchange rate handler observation subject interface.
    /// </summary>
    public interface IExchangeRateHandlerSubject
    {
        /// <summary>
        /// Represents current exchange rate request.
        /// </summary>
        public IExchangeRateRequest Request { get; set; }
        /// <summary>
        /// Represents current exchange rate handler strategy.
        /// </summary>
        public IExchangeRateHandlerStrategy Strategy { get; set; }

        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">Exchange rate handler observer.</param>
        void Attach(IExchangeRateHandlerObserver observer);
        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        /// <param name="observer">Exchange rate handler observer.</param>
        void Detach(IExchangeRateHandlerObserver observer);
        /// <summary>
        /// Notifies the subject's observers of state update. 
        /// </summary>
        void Notify();
    }
}
