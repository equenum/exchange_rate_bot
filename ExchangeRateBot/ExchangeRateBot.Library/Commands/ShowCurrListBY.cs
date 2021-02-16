using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Commands
{
    public class ShowCurrListBY : IShowCurrListBY
    {
        private readonly IChatMessageSender _chatMessageSender;
        private readonly string _supportedCurrencies;
        private readonly string _headNoteMessage;
        private readonly string _footNoteMessage;
        private readonly string _name;

        public ShowCurrListBY(IChatMessageSender chatMessageSender)
        {
            _name = "/SHOWCURRLISTBY";
            _headNoteMessage = "Available currencies for BY:";
            _footNoteMessage = "Note: Use 'RUR' instead of 'RUB' for 1998 and earlier years.";
            _chatMessageSender = chatMessageSender;
            _supportedCurrencies = GetValuesFromEnum();

            string GetValuesFromEnum()
            {
                StringBuilder stringBuilder = new StringBuilder();
                var currencies = (string[])Enum.GetNames(typeof(SupportedCurrenciesBY));

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

        public bool Contains(string command)
        {
            return command.Contains($"@{ BotSettings.Name }") && command.Contains(this._name);
        }

        public async Task Execute(Message message, ITelegramBotClient telegramBotClient)
        {
            string availableCurrencies = $"{ _headNoteMessage }\n" +
                                          $"{ _supportedCurrencies }\n\n" +
                                          $"{ _footNoteMessage }";

            await _chatMessageSender.SendShowCurrListMessage(message, availableCurrencies, telegramBotClient);
        }
    }
}
