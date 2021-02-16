using ExchangeRateBot.Library.Models;
using System.Threading.Tasks;

namespace ExchangeRateBot.Library.Utilities
{
    public interface IExchangeRateHandler
    {
        Task<IExchangeRate> LoadExchangeRate();
        void SetNewInput(string inputMessage);
    }
}