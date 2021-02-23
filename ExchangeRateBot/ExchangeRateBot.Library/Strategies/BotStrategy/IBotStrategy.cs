using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Strategy
{
    /// <summary>
    /// Represents a command strategy interface.
    /// </summary>
    public interface IBotStrategy
    {
        /// <summary>
        /// Represents current telegram bot command type.
        /// </summary>
        public CommandType CommandType { get; set; }

        /// <summary>
        /// Execites the command strategy asynchronously.
        /// </summary>
        /// <param name="message">Chat message.</param>
        /// <param name="telegramBotClient">Telergam bot client.</param>
        /// <param name="commandType">Command type.</param>
        Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient);
    }
}