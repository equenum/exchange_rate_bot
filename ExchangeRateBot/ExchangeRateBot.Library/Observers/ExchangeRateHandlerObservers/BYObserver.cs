using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Strategies;
using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers
{
    public class BYObserver : IExchangeRateHandlerObserver
    {
        private readonly string _country;

        public BYObserver()
        {
            _country = $"{ nameof(SupportedContries.BY).ToUpper() }";
        }

        public void Update(IExchangeRateHandlerSubject subject)
        {
            if (subject.Request.Country == _country)
            {
                subject.Strategy = Factory.CreateBYExchangeRateHandlerStrategy();
            }
        }
    }
}
