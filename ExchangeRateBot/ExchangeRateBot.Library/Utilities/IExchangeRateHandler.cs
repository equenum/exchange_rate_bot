using ExchangeRateBot.Library.Models;
using System.Threading.Tasks;

namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents an interface for an ExchangeRateHandler.
    /// </summary>
    public interface IExchangeRateHandler
    {
        /// <summary>
        /// Loads exchange rate.
        /// </summary>
        /// <returns>Exchange rate.</returns>
        Task<IExchangeRate> LoadExchangeRate();
        /// <summary>
        /// Sets a new chat input value for loading.
        /// </summary>
        /// <param name="inputMessage">Chat input value.</param>
        void SetNewInput(string inputMessage);
    }
}