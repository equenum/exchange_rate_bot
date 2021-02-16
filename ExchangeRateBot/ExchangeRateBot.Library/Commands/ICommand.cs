using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Commands
{
    /// <summary>
    /// Represents a command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="message">Chat input message.</param>
        /// <param name="telegramBotClient">Telegram bot client.</param>
        /// <returns></returns>
        Task Execute(Message message, ITelegramBotClient telegramBotClient);
        /// <summary>
        /// Verifies if chat input message contains the command.
        /// </summary>
        /// <param name="command">Chat input message.</param>
        /// <returns>Message evaluation result.</returns>
        bool Contains(string command);
    }
}
