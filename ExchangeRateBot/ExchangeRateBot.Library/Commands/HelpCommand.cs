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
    /// Represents a help command class.
    /// </summary>
    public class HelpCommand : ICommand
    {
        private readonly IChatMessageSender _chatMessageSender;

        public CommandType CommandType => CommandType.Help;

        public HelpCommand(IChatMessageSender chatMessageSender)
        {
            _chatMessageSender = chatMessageSender;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            const string HelpMessage = "You can control me by sending these commands:\n\n" +
                                        "/start - start bot\n" +
                                        "/now - show current date and time\n" +
                                        "/exchangerate - show exchange rate\n" +
                                        "/showcurrlistby - show available currencies for BY\n" +
                                        "/showcurrlistua - show available currencies for UA\n" +
                                        "/help - show help information\n\n" +
                                        "Note: \nUse @botname before every command call.\n\n" +
                                        "Exchange rate command example:\n" +
                                        "@botname /exchangerate USD 2021-01-01 BY/UA\n" +
                                        "Date format: YY-MM-DD";

            await _chatMessageSender.SendHelpMessageAsync(message, HelpMessage, telegramBotClient);
        }
    }
}
