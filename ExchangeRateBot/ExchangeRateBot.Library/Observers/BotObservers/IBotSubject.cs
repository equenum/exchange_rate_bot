using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    /// <summary>
    /// Represents a telegram bot observation subject interface.
    /// </summary>
    public interface IBotSubject
    {
        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">Bot observer.</param>
        void Attach(IBotObserver observer);
        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        /// <param name="observer"Bot observer.></param>
        void Detach(IBotObserver observer);
        /// <summary>
        /// Notifies the subject's observers of state update. 
        /// </summary>
        void Notify();
    }
}
