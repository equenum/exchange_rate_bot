using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Commands
{
    /// <summary>
    /// Represents a start command.
    /// </summary>
    public class StartCommand : ICommand
    {
        private readonly IChatMessageSender _chatMessageSender;

        public CommandType CommandType => CommandType.Start;

        public StartCommand(IChatMessageSender chatMessageSender)
        {
            _chatMessageSender = chatMessageSender;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            string startMessage = $"Hello! I can help you get exchange rate records\n" +
                                  $"from Belarusian and Ukrainian national banks archives.\n\n" +
                                  $"Use /help to get instructions.";

            await _chatMessageSender.SendStartMessageAsync(message, startMessage, telegramBotClient);
        }
    }
}
