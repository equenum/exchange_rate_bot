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
    public class StartCommand : IStartCommand
    {
        private readonly IChatMessageSender _chatMessageSender;
        private readonly string _name;

        public StartCommand(IChatMessageSender chatMessageSender)
        {
            _name = "/START";
            _chatMessageSender = chatMessageSender;
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            string startMessage = $"Hello! I can help you get exchange rate records\n" +
                                  $"from Belarusian and Ukrainian national banks archives.\n\n" +
                                  $"Use /help to get instructions.";

            await _chatMessageSender.SendStartMessage(message, startMessage, telegramBotClient);
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this._name);
        }
    }
}
