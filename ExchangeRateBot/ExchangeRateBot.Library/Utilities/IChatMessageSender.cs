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
        Task SendExchangeRateMessageAsync(Message message, IExchangeRate exchangeRate, ITelegramBotClient telegramBotClient);
        Task SendHelpMessageAsync(Message message, string helpMessage, ITelegramBotClient telegramBotClient);
        Task SendNowMessageAsync(Message message, ITelegramBotClient telegramBotClient);
        Task SendShowCurrListMessageAsync(Message message, string supportedCurrencies, ITelegramBotClient telegramBotClient);
        Task SendStartMessageAsync(Message message, string startMessage, ITelegramBotClient telegramBotClient);
        Task SendUnavailableRateMessageAsync(Message message, ITelegramBotClient telegramBotClient);
        Task SendUnrecognizedCommandMessageAsync(Message message, ITelegramBotClient telegramBotClient);
        Task SendValidationErrorMessageAsync(Message message, string errorMessage, ITelegramBotClient telegramBotClient);
    }
}