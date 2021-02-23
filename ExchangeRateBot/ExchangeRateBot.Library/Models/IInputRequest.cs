namespace ExchangeRateBot.Library.Models
{
    /// <summary>
    /// Represents an input exchange rate request interface.
    /// </summary>
    public interface IInputRequest
    {
        /// <summary>
        /// Represents target country.
        /// </summary>
        string Country { get; set; }
        /// <summary>
        /// Represents target currency.
        /// </summary>
        string Currency { get; set; }
        /// <summary>
        /// Represents target date.
        /// </summary>
        string Date { get; set; }
    }
}