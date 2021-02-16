﻿using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.Library.Commands
{
    public class HelpCommand : IHelpCommand
    {
        private readonly IChatMessageSender _chatMessageSender;
        private readonly string _name;

        public HelpCommand(IChatMessageSender chatMessageSender)
        {
            _name = "/HELP";
            _chatMessageSender = chatMessageSender;
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            const string HelpMessage = "You can control me by sending these commands:\n\n" +
                                        "/now - send current date and time\n" +
                                        "/test - send test message\n";

            await _chatMessageSender.SendHelpMessage(message, HelpMessage, telegramBotClient);
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this._name);
        }
    }
}
