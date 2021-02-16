namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents an interface for exchange rate message validator.
    /// </summary>
    public interface IExchangeRateMessageValidator
    {
        /// <summary>
        /// Gets validation error message.
        /// </summary>
        /// <returns>Validation error message</returns>
        string GetErrorMessage();
        /// <summary>
        /// Sets new input value for validation.
        /// </summary>
        /// <param name="inputMessage">Input chat value.</param>
        void SetNewInput(string inputMessage);
        /// <summary>
        /// Validates chat message.
        /// </summary>
        /// <returns>Chat message validation result.</returns>
        bool Validate();
    }
}