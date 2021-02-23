using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Strategies;
using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers
{
    public class UAObserver : IExchangeRateHandlerObserver
    {
        private readonly string _country;

        public UAObserver()
        {
            _country = $"{ nameof(SupportedContries.UA).ToUpper() }";
        }

        public void Update(IExchangeRateHandlerSubject subject)
        {
            if (subject.Request.Country == _country)
            {
                subject.Strategy = Factory.CreateUAExchangeRateHandlerStrategy();
            }
        }
    }
}
