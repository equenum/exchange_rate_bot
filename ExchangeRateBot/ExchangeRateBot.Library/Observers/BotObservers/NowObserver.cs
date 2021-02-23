using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    public class NowObserver : IBotObserver
    {
        private readonly IBotStrategy _commandStrategy; 
        private readonly string _commandName;

        public NowObserver(IBotStrategy commandStrategy)
        {
            _commandStrategy = commandStrategy;
            _commandName = $"/{ nameof(CommandType.Now).ToUpper() }";
        }

        public void Update(IBot subject)
        {
            if (subject.Command == _commandName)
            {
                _commandStrategy.CommandType = CommandType.Now;
                subject.Strategy = _commandStrategy;
            }
        }
    }
}
