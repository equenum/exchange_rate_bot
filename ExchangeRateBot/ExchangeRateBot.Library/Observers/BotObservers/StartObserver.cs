using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    public class StartObserver : IBotObserver
    {
        private readonly IBotStrategy _commandStrategy;
        private readonly string _commandName;

        public StartObserver(IBotStrategy commandStrategy)
        {
            _commandStrategy = commandStrategy;
            _commandName = $"/{ nameof(CommandType.Start).ToUpper() }";
        }

        public void Update(IBot subject)
        {
            if (subject.Command == _commandName)
            {
                _commandStrategy.CommandType = CommandType.Start;
                subject.Strategy = _commandStrategy;
            }
        }
    }
}
