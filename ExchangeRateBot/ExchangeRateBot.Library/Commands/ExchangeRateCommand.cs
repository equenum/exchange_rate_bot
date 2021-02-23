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
    public class ExchangeRateCommand : ICommand
    {
        private readonly IExchangeRateMessageValidator _exchangeMessageValidator;
        private readonly IExchangeRateHandler _exchangeRateHandler;
        private readonly IChatMessageSender _chatMessageSender;

        public CommandType CommandType => CommandType.ExchangeRate;

        public ExchangeRateCommand(
            IExchangeRateMessageValidator exchangeMessageValidator, 
            IExchangeRateHandler exchangeRateHandler, 
            IChatMessageSender chatMessageSender)
        {
            _exchangeMessageValidator = exchangeMessageValidator;
            _exchangeRateHandler = exchangeRateHandler;
            _chatMessageSender = chatMessageSender;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            var messageText = message.Text.ToUpper();

            _exchangeMessageValidator.SetNewInputRequest(messageText);

            if (_exchangeMessageValidator.Validate())
            {
                _exchangeRateHandler.SetNewRequest(messageText);

                var exchangeRate = await _exchangeRateHandler.GetExchangeRate();

                if (exchangeRate != null)
                {
                    await _chatMessageSender.SendExchangeRateMessageAsync(message, exchangeRate, telegramBotClient);
                }
                else
                {
                    await _chatMessageSender.SendUnavailableRateMessageAsync(message, telegramBotClient);
                }
            }
            else
            {
                var errorMessage = _exchangeMessageValidator.GetErrorMessage();

                await _chatMessageSender.SendValidationErrorMessageAsync(message, errorMessage, telegramBotClient);
            }
        }
    }
}
