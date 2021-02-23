using ExchangeRateBot.Library.Models;

namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents an interface for exchange rate message validator.
    /// </summary>
    public interface IExchangeRateMessageValidator
    {
        /// <summary>
        /// Represents current exchange rate request.
        /// </summary>
        public IInputRequest Request { get; set; }

        /// <summary>
        /// Gets validation error message.
        /// </summary>
        /// <returns>Validation error message</returns>
        string GetErrorMessage();
        /// <summary>
        /// Sets new input exchange rate request for validation.
        /// </summary>
        /// <param name="inputMessage">Input chat request.</param>
        void SetNewInputRequest(string inputMessage);
        /// <summary>
        /// Validates chat message.
        /// </summary>
        /// <returns>Chat message validation result.</returns>
        bool Validate();
    }
}