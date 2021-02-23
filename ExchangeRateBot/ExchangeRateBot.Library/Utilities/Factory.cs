using ExchangeRateBot.Library.Models;
using ExchangeRateBot.Library.Strategies;
using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents a class factory. 
    /// </summary>
    public static class Factory
    {
        public static IInputRequest CreateInputRequest()
        {
            return new InputRequest();
        }

        public static IExchangeRateRequest CreateExchangeRequest()
        {
            return new ExchangeRateRequest();
        }

        public static IExchangeRateHandlerStrategy CreateUAExchangeRateHandlerStrategy()
        { 
            return new UAExchangeRateHandlerStrategy();
        }

        public static IExchangeRateHandlerStrategy CreateBYExchangeRateHandlerStrategy()
        {
            return new BYExchangeRateHandlerStrategy();
        }
    }
}
