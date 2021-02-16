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
    public class NowCommand : INowCommand
    {
        private readonly IChatMessageSender _chatMessageSender;
        private readonly string _name;

        public NowCommand(IChatMessageSender chatMessageSender)
        {
            _name = "/NOW";
            _chatMessageSender = chatMessageSender;
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            await _chatMessageSender.SendNowMessage(message, telegramBotClient);
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this._name);
        }
    }
}
