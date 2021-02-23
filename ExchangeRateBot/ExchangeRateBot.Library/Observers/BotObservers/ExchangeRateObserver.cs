using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    public class ExchangeRateObserver : IBotObserver
    {
        private readonly IBotStrategy _commandStrategy; 
        private readonly string _commandName;

        public ExchangeRateObserver(IBotStrategy commandStrategy)
        {
            _commandStrategy = commandStrategy;
            _commandName = $"/{ nameof(CommandType.ExchangeRate).ToUpper() }";
        }

        public void Update(IBot subject)
        {
            if (subject.Command == _commandName)
            {
                _commandStrategy.CommandType = CommandType.ExchangeRate;
                subject.Strategy = _commandStrategy;
            }
        }
    }
}
