using ExchangeRateBot.Library.Strategy;

namespace ExchangeRateBot.Library
{
    /// <summary>
    /// Represents a telegram bot interface.
    /// </summary>
    public interface IBot
    {
        /// <summary>
        /// Represents current telegram bot chat command.
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// Represents current telegram bot command strategy.
        /// </summary>
        public IBotStrategy Strategy { get; set; }

        /// <summary>
        /// Runs the telegram bot application.
        /// </summary>
        void Run();
    }
}