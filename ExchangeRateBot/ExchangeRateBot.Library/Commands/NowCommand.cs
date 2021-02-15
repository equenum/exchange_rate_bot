using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.Library.Commands
{
    public class NowCommand : ICommand
    {
        public string Name { get; }

        public NowCommand()
        {
            Name = "/NOW";
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                       chatId: message.Chat,
                       text: $"Current date and time:  { DateTime.Now.ToLocalTime() }",
                       parseMode: ParseMode.Markdown,
                       disableNotification: true,
                       replyToMessageId: message.MessageId
                   //replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                   //"Check detailed info",
                   //"https://core.telegram.org/bots/api#sendmessage"
                   //))
                   );
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this.Name);
        }
    }
}
