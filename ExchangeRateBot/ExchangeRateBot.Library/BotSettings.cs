using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot
{
    /// <summary>
    /// Represents telegram bot settings.
    /// </summary>
    public static class BotSettings
    {
        /// <summary>
        /// Represents telegram bot name.
        /// </summary>
        public static string Name { get; set; } = "";
        /// <summary>
        /// Represents telegram bot api-token.
        /// </summary>
        public static string BotToken { get; set; } = "";
    }
}
