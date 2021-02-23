using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Observers
{
    public class ShowCurrListUAObserver : IBotObserver
    {
        private readonly IBotStrategy _commandStrategy;
        private readonly string _commandName;

        public ShowCurrListUAObserver(IBotStrategy commandStrategy)
        {
            _commandStrategy = commandStrategy;
            _commandName = $"/{ nameof(CommandType.ShowCurrListUA).ToUpper() }";
        }

        public void Update(IBot subject)
        {
            if (subject.Command == _commandName)
            {
                _commandStrategy.CommandType = CommandType.ShowCurrListUA;
                subject.Strategy = _commandStrategy;
            }
        }
    }
}
