using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Threading.Tasks;
using ExchangeRateBot.Library.Models;

namespace ExchangeRateBot.Library.Utilities
{
    public class ChatMessageSender : IChatMessageSender
    {
        public async Task SendUnrecognizedCommandMessage(Message message, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: "Unrecognized command. Say what?",
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
        }

        public async Task SendExchangeRateMessage(Message message, IExchangeRate exchangeRate, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: $"{ exchangeRate.GetTargetCurrency() } / { exchangeRate.GetHomeCurrency() } : " +
                              $"{ exchangeRate.GetRate() }",
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
        }

        public async Task SendUnavailableRateMessage(Message message, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: "Exchange rate is not available",
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
        }

        public async Task SendValidationErrorMessage(Message message, string errorMessage, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: errorMessage,
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
        }

        public async Task SendHelpMessage(Message message, string helpMessage, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: helpMessage,
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
        }

        public async Task SendNowMessage(Message message, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                       chatId: message.Chat,
                       text: $"Current date and time:  { DateTime.Now.ToLocalTime() }",
                       parseMode: ParseMode.Markdown,
                       disableNotification: true,
                       replyToMessageId: message.MessageId
                   );
        }

        public async Task SendShowCurrListMessage(Message message, string supportedCurrencies, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: supportedCurrencies,
                       parseMode: ParseMode.Markdown,
                       disableNotification: true,
                       replyToMessageId: message.MessageId
                   );
        }

        public async Task SendStartMessage(Message message, string startMessage, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: startMessage,
                       parseMode: ParseMode.Markdown,
                       disableNotification: true,
                       replyToMessageId: message.MessageId
                   );
        }
    }
}
