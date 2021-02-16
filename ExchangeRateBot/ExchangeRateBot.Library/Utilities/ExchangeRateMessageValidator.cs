using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Utilities
{
    /// <summary>
    /// Represents an exchange rate message validator.
    /// </summary>
    public class ExchangeRateMessageValidator : IExchangeRateMessageValidator
    {
        private readonly DateTime _archiveBeginningDateBY;
        private readonly DateTime _archiveBeginningDateUA;
        private string _errorMessage;
        private string _currency;
        private string _date;
        private string _country;

        public ExchangeRateMessageValidator()
        {
            _archiveBeginningDateBY = new DateTime(1996, 1, 1);
            _archiveBeginningDateUA = new DateTime(2010, 1, 1);
        }

        public bool Validate()
        {
            if (CurrencyIsValid() && CountryIsValid() && DateIsValid())
            {
                return true;
            }
            else
            {
                return false;
            }

            bool CurrencyIsValid()
            {
                bool result = true;

                switch (_country)
                {
                    case "BY":
                        result = Enum.IsDefined(typeof(SupportedCurrenciesBY), _currency);
                        if (result == false)
                        {
                            _errorMessage = "Invalid currency code!";
                        }
                        return result;
                    case "UA":
                        result = Enum.IsDefined(typeof(SupportedCurrenciesUA), _currency);
                        if (result == false)
                        {
                            _errorMessage = "Invalid currency code!";
                        }
                        return result;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            bool CountryIsValid()
            {
                if (Enum.IsDefined(typeof(SupportedContries), _country))
                {
                    return true;
                }
                else
                {
                    _errorMessage = "Invalid counrty code!";

                    return false;
                }
            }

            bool DateIsValid()
            {
                DateTime date;
                DateTime currentDate = DateTime.Now;

                bool result = false;

                try
                {
                    date = DateTime.ParseExact(_date, "yyyy-MM-dd",
                                      System.Globalization.CultureInfo.InvariantCulture);

                    if (YearIsValid() && MonthIsValid() && DayIsValid())
                    {
                        result = true;
                    }
                    else
                    {
                        _errorMessage = "Invalid date!";
                    }
                }
                catch (Exception)
                {
                    _errorMessage = "Invalid date!";

                    return result;
                }

                return result;

                bool YearIsValid()
                {
                    switch (_country)
                    {
                        case "BY":
                            return date.Year <= currentDate.Year && date.Year >= _archiveBeginningDateBY.Year;
                        case "UA":
                            return date.Year <= currentDate.Year && date.Year >= _archiveBeginningDateUA.Year;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                bool MonthIsValid()
                {
                    switch (_country)
                    {
                        case "BY":
                            return date.Month <= currentDate.Month && date.Month >= _archiveBeginningDateBY.Month;
                        case "UA":
                            return date.Month <= currentDate.Month && date.Month >= _archiveBeginningDateUA.Month;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                bool DayIsValid()
                {
                    switch (_country)
                    {
                        case "BY":
                            return date.Day <= currentDate.Day && date.Day >= _archiveBeginningDateBY.Day;
                        case "UA":
                            return date.Day <= currentDate.Day && date.Day >= _archiveBeginningDateUA.Day;
                        default:
                            throw new ArgumentOutOfRangeException(); 
                    }
                }
            }
        }

        public string GetErrorMessage()
        {
            var message = _errorMessage;
            _errorMessage = string.Empty;

            return message;
        }

        public void SetNewInput(string inputMessage)
        {
            var message = inputMessage.Split(' ');

            _currency = message[2];
            _date = message[3];
            _country = message[4];
        }
    }
}
