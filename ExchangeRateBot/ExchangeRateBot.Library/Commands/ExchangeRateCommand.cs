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
    public class ExchangeRateCommand : ICommand
    {
        private readonly ExchangeRateMessageValidator _exchangeMessageValidator; // TODO : DI
        private readonly ExchangeRateHandler _exchangeRateHandler;

        public string Name { get; }

        public ExchangeRateCommand()
        {
            Name = "/EXCHANGERATE";

            _exchangeMessageValidator = new ExchangeRateMessageValidator();
            _exchangeRateHandler = new ExchangeRateHandler();
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            var messageText = message.Text;

            _exchangeMessageValidator.Input = messageText; // TODO : Create a method to set this parameter 

            if (_exchangeMessageValidator.Validate())
            {
                _exchangeRateHandler.Input = messageText; // TODO : Create a method to set this parameter 

                var exchangeRate = await _exchangeRateHandler.LoadExchangeRate();

                await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: $"{ exchangeRate.GetTargetCurrency() } / { exchangeRate.GetHomeCurrency() } : " +
                              $"{ exchangeRate.GetRate() }",
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
            }
            else
            {
                var errorMessage = _exchangeMessageValidator.GetErrorMessage();

                await telegramBotClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: errorMessage,
                        parseMode: ParseMode.Markdown,
                        disableNotification: true,
                        replyToMessageId: message.MessageId
                    );
            }
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this.Name);
        }
    }
}
