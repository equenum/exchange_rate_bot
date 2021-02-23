using ExchangeRateBot.Library.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Tests.Observers
{
    public class ObserverTestCommand : ICommand
    {
        public CommandType CommandType { get; set; }

        public Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            throw new NotImplementedException();
        }
    }
}
