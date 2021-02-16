using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateBot.Library.Commands
{
    /// <summary>
    /// Representa an interface for showing current 
    /// date and time command. 
    /// </summary>
    public interface INowCommand : ICommand
    {
    }
}