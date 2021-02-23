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
        Task<IExchangeRate> GetExchangeRate();
        /// <summary>
        /// Sets a new chat input exchange rate request for loading.
        /// </summary>
        /// <param name="inputMessage">Chat input exchange rate request.</param>
        void SetNewRequest(string inputMessage);
    }
}