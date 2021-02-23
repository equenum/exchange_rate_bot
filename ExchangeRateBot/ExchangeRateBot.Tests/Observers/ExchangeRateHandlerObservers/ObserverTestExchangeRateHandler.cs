using ExchangeRateBot.Library.Models;
using ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers;
using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Strategies;
using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateBot.Tests.Observers.ExchangeRateHandlerObservers
{
    public class ObserverTestExchangeRateHandler : IExchangeRateHandler, IExchangeRateHandlerSubject
    {
        private readonly IEnumerable<IExchangeRateHandlerObserver> _availableObservers;
        private List<IExchangeRateHandlerObserver> _observers;

        public IExchangeRateRequest Request { get; set; }
        public IExchangeRateHandlerStrategy Strategy { get; set; }

        public ObserverTestExchangeRateHandler(List<IExchangeRateHandlerObserver> availableObservers)
        {
            _observers = new List<IExchangeRateHandlerObserver>();
            _availableObservers = availableObservers;

            AttachObservers();
        }


        public void Attach(IExchangeRateHandlerObserver observer)
        {
            if (_observers.Contains(observer) == false)
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IExchangeRateHandlerObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public Task<IExchangeRate> GetExchangeRate()
        {
            Notify();

            return null;
        }

        public void Notify()
        {
            if (_observers.Count > 0)
            {
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }

        public void SetNewRequest(string requestMessage)
        {
            var requestDetails = requestMessage.Split(' ');

            if (requestDetails.Length == 4)
            {
                Request = new ExchangeRateRequest
                {
                    Currency = requestDetails[2],
                    Date = DateTime.ParseExact(
                        requestDetails[3], "yyyy-MM-dd",
                        System.Globalization.CultureInfo.InvariantCulture
                        ),
                    Country = "UA"
                };
            }
            else
            {
                Request = new ExchangeRateRequest
                {
                    Currency = requestDetails[2],
                    Date = DateTime.ParseExact(
                    requestDetails[3], "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture
                    ),
                    Country = requestDetails[4]
                };
            }
        }

        private void AttachObservers()
        {
            foreach (var observer in _availableObservers)
            {
                if (_observers.Contains(observer) == false)
                {
                    _observers.Add(observer);
                }
            }
        }
    }
}
