using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.Library.Commands
{
    /// <summary>
    /// Representa a class for showing current date and time command. 
    /// </summary>
    public class NowCommand : ICommand
    {
        private readonly IChatMessageSender _chatMessageSender;

        public CommandType CommandType => CommandType.Now;

        public NowCommand(IChatMessageSender chatMessageSender)
        {
            _chatMessageSender = chatMessageSender;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            await _chatMessageSender.SendNowMessageAsync(message, telegramBotClient);
        }
    }
}
