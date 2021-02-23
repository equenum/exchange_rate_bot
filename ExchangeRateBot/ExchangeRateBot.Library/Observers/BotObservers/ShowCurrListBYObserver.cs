using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    public class ShowCurrListBYObserver : IBotObserver
    {
        private readonly IBotStrategy _commandStrategy;
        private readonly string _commandName;

        public ShowCurrListBYObserver(IBotStrategy commandStrategy)
        {
            _commandStrategy = commandStrategy;
            _commandName = $"/{ nameof(CommandType.ShowCurrListBY).ToUpper() }";
        }

        public void Update(IBot subject)
        {
            if (subject.Command == _commandName)
            {
                _commandStrategy.CommandType = CommandType.ShowCurrListBY;
                subject.Strategy = _commandStrategy;
            }
        }
    }
}
