using ExchangeRateBot.Library.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Strategy
{
    /// <summary>
    /// Represents a command strategy.
    /// </summary>
    public class BotStrategy : IBotStrategy
    {
        private readonly IEnumerable<ICommand> _commands;

        public CommandType CommandType { get; set; }

        public BotStrategy(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient telegramBotClient)
        {
            await _commands.FirstOrDefault(x => x.CommandType == this.CommandType)?.ExecuteAsync(message, telegramBotClient);
        }
    }
}
