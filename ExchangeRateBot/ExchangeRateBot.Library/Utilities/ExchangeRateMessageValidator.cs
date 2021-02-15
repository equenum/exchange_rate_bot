using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Library.Utilities
{
    public class ExchangeRateMessageValidator
    {
        private string _errorMessage;

        public string Input
        {
            set
            {
                var message = value.Split(' ');

                _currency = message[2];
                _date = message[3];
                _country = message[4];
            }
        }

        private string _currency;
        private string _date;
        private string _country;

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
                if (Enum.IsDefined(typeof(SupportedCurrencies), _currency))
                {
                    return true;
                }
                else
                {
                    _errorMessage = "Invalid currency code!";

                    return false;
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

                bool YearIsValid()
                {
                    switch (_country)
                    {
                        case "BY":
                            return date.Year <= currentDate.Year && date.Year >= 1995;
                        case "UA":
                            return date.Year <= currentDate.Year && date.Year >= (currentDate.Year - 4);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                bool MonthIsValid()
                {
                    return date.Month <= currentDate.Month;
                }

                bool DayIsValid()
                {
                    return date.Day <= currentDate.Day;
                }

                return result;
            }
        }

        public string GetErrorMessage()
        {
            var message = _errorMessage;
            _errorMessage = string.Empty;

            return message;
        }
    }
}
