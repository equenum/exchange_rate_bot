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
    /// Represents a class for showing exchange rate command.
    /// </summary>
    public class ExchangeRateCommand : IExchangeRateCommand
    {
        private readonly IExchangeRateMessageValidator _exchangeMessageValidator;
        private readonly IExchangeRateHandler _exchangeRateHandler;
        private readonly IChatMessageSender _chatMessageSender;
        private readonly string _name;

        public ExchangeRateCommand(
            IExchangeRateMessageValidator exchangeMessageValidator, 
            IExchangeRateHandler exchangeRateHandler, 
            IChatMessageSender chatMessageSender)
        {
            _name = "/EXCHANGERATE";
            _exchangeMessageValidator = exchangeMessageValidator;
            _exchangeRateHandler = exchangeRateHandler;
            _chatMessageSender = chatMessageSender;
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            var messageText = message.Text;

            _exchangeMessageValidator.SetNewInput(messageText);

            if (_exchangeMessageValidator.Validate())
            {
                _exchangeRateHandler.SetNewInput(messageText);

                var exchangeRate = await _exchangeRateHandler.LoadExchangeRate();

                if (exchangeRate != null)
                {
                    await _chatMessageSender.SendExchangeRateMessage(message, exchangeRate, telegramBotClient);
                }
                else
                {
                    await _chatMessageSender.SendUnavailableRateMessage(message, telegramBotClient);
                }
            }
            else
            {
                var errorMessage = _exchangeMessageValidator.GetErrorMessage();

                await _chatMessageSender.SendValidationErrorMessage(message, errorMessage, telegramBotClient);
            }
        }

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this._name);
        }
    }
}
