using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Commands
{
    /// <summary>
    /// Represents a class for showing available currency list for Ukraine. 
    /// </summary>
    public class ShowCurrListUACommand : ICommand
    {
        private readonly IChatMessageSender _chatMessageSender;
        private readonly string _supportedCurrencies;
        private readonly string _headNoteMessage;
        private readonly string _footNoteMessage;

        public CommandType CommandType => CommandType.ShowCurrListUA;

        public ShowCurrListUACommand(IChatMessageSender chatMessageSender)
        {
            _headNoteMessage = "Available currencies for UA:";
            _footNoteMessage = "Note: Use 'BYR' instead of 'BYN' for 2016 and earlier years.";
            _chatMessageSender = chatMessageSender;
            _supportedCurrencies = GetValuesFromEnum();
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            string availableCurrencies = $"{ _headNoteMessage }\n" +
                                         $"{ _supportedCurrencies }\n\n" +
                                         $"{ _footNoteMessage }";

            await _chatMessageSender.SendShowCurrListMessageAsync(message, availableCurrencies, telegramBotClient);
        }

        private string GetValuesFromEnum()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var currencies = (string[])Enum.GetNames(typeof(SupportedCurrenciesUA));

            for (int i = 0; i <= currencies.Length - 1; i++)
            {
                if (i != currencies.Length - 1)
                {
                    stringBuilder.Append($"{ currencies[i] },\n");
                }
                else
                {
                    stringBuilder.Append($"{ currencies[i] }");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
