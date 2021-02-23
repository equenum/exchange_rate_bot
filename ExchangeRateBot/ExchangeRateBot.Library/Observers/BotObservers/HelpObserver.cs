using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    public class HelpObserver : IBotObserver
    {
        private readonly IBotStrategy _commandStrategy; 
        private readonly string _commandName;

        public HelpObserver(IBotStrategy commandStrategy)
        {
            _commandStrategy = commandStrategy;
            _commandName = $"/{ nameof(CommandType.Help).ToUpper() }";
        }

        public void Update(IBot subject)
        {
            if (subject.Command == _commandName)
            {
                _commandStrategy.CommandType = CommandType.Help;
                subject.Strategy = _commandStrategy;
            }
        }
    }
}
