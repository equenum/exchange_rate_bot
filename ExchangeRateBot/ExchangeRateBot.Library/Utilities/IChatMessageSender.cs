using ExchangeRateBot.Library.Models;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents an interface for ChatMessageSender.
    /// </summary>
    public interface IChatMessageSender
    {
        Task SendExchangeRateMessage(Message message, IExchangeRate exchangeRate, ITelegramBotClient telegramBotClient);
        Task SendHelpMessage(Message message, string helpMessage, ITelegramBotClient telegramBotClient);
        Task SendNowMessage(Message message, ITelegramBotClient telegramBotClient);
        Task SendShowCurrListMessage(Message message, string supportedCurrencies, ITelegramBotClient telegramBotClient);
        Task SendStartMessage(Message message, string startMessage, ITelegramBotClient telegramBotClient);
        Task SendUnavailableRateMessage(Message message, ITelegramBotClient telegramBotClient);
        Task SendUnrecognizedCommandMessage(Message message, ITelegramBotClient telegramBotClient);
        Task SendValidationErrorMessage(Message message, string errorMessage, ITelegramBotClient telegramBotClient);
    }
}