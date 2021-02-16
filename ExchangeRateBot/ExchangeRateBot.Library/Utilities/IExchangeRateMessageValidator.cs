namespace ExchangeRateBot.Library.Utilities
{
    public interface IExchangeRateMessageValidator
    {
        string GetErrorMessage();
        void SetNewInput(string inputMessage);
        bool Validate();
    }
}