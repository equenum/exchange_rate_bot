using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.Library.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name { get; }

        public HelpCommand()
        {
            Name = "/HELP";
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            const string Help = "You can control me by sending these commands:\n\n" +
                                        "/now - send current date and time\n" +
                                        "/test - send test message\n";

            await telegramBotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: Help,
                parseMode: ParseMode.Markdown,
                disableNotification: true,
                replyToMessageId: message.MessageId
            );
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this.Name);
        }
    }
}
