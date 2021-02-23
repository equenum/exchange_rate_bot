using ExchangeRateBot.Library.Models;
using Serilog;
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
        private string[] _inputMessage;

        public IInputRequest Request { get; set; }

        public ExchangeRateMessageValidator()
        {
            _archiveBeginningDateBY = new DateTime(1996, 1, 1);
            _archiveBeginningDateUA = new DateTime(2010, 1, 1);
        }

        public bool Validate()
        {
            if (_inputMessage.Length >= 4 && _inputMessage.Length < 6)
            {
                CreateRequest();

                if (CountryIsValid() && CurrencyIsValid() && DateIsValid())
                {
                    return true;
                }
                else
                {
                    Log.Error($"Exchange rate request validation error: { _errorMessage }.");

                    return false;
                }
            }
            else
            {
                _errorMessage = "Invalid command format!";
                Log.Error($"Exchange rate request validation error: { _errorMessage }.");

                return false;
            }
        }

        public string GetErrorMessage()
        {
            var message = _errorMessage;
            _errorMessage = string.Empty;

            return message;
        }

        public void SetNewInputRequest(string inputMessage)
        {
            _inputMessage = inputMessage.Split(' ');
        }

        private void CreateRequest()
        {
            IInputRequest inputRequest = Factory.CreateInputRequest();

            if (_inputMessage.Length == 4)
            {
                inputRequest.Currency = _inputMessage[2];
                inputRequest.Date = _inputMessage[3];

                Request = inputRequest;
            }
            else
            {
                inputRequest.Currency = _inputMessage[2];
                inputRequest.Date = _inputMessage[3];
                inputRequest.Country = _inputMessage[4];

                Request = inputRequest;
            }
        }

        private bool CurrencyIsValid()
        {
            if (Request.Country != null)
            {
                bool result;

                switch (Request.Country)
                {
                    case "BY":
                        result = Enum.IsDefined(typeof(SupportedCurrenciesBY), Request.Currency);
                        if (result == false)
                        {
                            _errorMessage = "Invalid currency code!";
                        }
                        return result;
                    case "UA":
                        result = Enum.IsDefined(typeof(SupportedCurrenciesUA), Request.Currency);
                        if (result == false)
                        {
                            _errorMessage = "Invalid currency code!";
                        }
                        return result;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                return true;
            }
        }

        private bool CountryIsValid()
        {
            if (Request.Country != null)
            {
                if (Enum.IsDefined(typeof(SupportedContries), Request.Country))
                {
                    return true;
                }
                else
                {
                    _errorMessage = "Invalid counrty code!";

                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool DateIsValid()
        {
            DateTime date;
            DateTime currentDate = DateTime.Now;

            bool result = false;

            try
            {
                date = DateTime.ParseExact(Request.Date, "yyyy-MM-dd",
                                  System.Globalization.CultureInfo.InvariantCulture);

                if (YearIsValid(date, currentDate) && MonthIsValid(date, currentDate) && DayIsValid(date, currentDate))
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
        }

        bool YearIsValid(DateTime date, DateTime currentDate)
        {
            if (Request.Country != null)
            {
                return Request.Country switch
                {
                    "BY" => date.Year <= currentDate.Year && date.Year >= _archiveBeginningDateBY.Year,
                    "UA" => date.Year <= currentDate.Year && date.Year >= _archiveBeginningDateUA.Year,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
            else
            {
                return date.Year <= currentDate.Year && date.Year >= _archiveBeginningDateUA.Year;
            }
        }

        bool MonthIsValid(DateTime date, DateTime currentDate)
        {
            if (Request.Country != null)
            {
                return Request.Country switch
                {
                    "BY" => date.Month <= currentDate.Month && date.Month >= _archiveBeginningDateBY.Month,
                    "UA" => date.Month <= currentDate.Month && date.Month >= _archiveBeginningDateUA.Month,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
            else
            {
                return date.Month <= currentDate.Month && date.Month >= _archiveBeginningDateUA.Month;
            }
        }

        bool DayIsValid(DateTime date, DateTime currentDate)
        {
            if (Request.Country != null)
            {
                return Request.Country switch
                {
                    "BY" => date.Day <= currentDate.Day && date.Day >= _archiveBeginningDateBY.Day,
                    "UA" => date.Day <= currentDate.Day && date.Day >= _archiveBeginningDateUA.Day,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
            else
            {
                return date.Day <= currentDate.Day && date.Day >= _archiveBeginningDateUA.Day;
            }
        }
    }
}
