using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Commands
{
    public interface ICommand
    {
        Task Execute(Message message, ITelegramBotClient telegramBotClient);
        bool Contains(string command);
    }
}
