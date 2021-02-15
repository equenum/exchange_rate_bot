using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.Library.Commands
{
    public class TestCommand : ICommand
    {
        public string Name { get; }

        public TestCommand()
        {
            Name = "/TEST";
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: "Test All Right",
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
