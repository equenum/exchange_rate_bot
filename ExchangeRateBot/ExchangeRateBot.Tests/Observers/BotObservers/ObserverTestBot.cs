using ExchangeRateBot.Library;
using ExchangeRateBot.Library.Observers;
using ExchangeRateBot.Library.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Tests.Observers
{
    public class ObserverTestBot : IBot, IBotSubject
    {
        private readonly List<IBotObserver> _observers;

        public string Command { get; set; }
        public IBotStrategy Strategy { get; set; }

        public ObserverTestBot(string command, IBotObserver botObserver)
        {
            Command = command;
            _observers = new List<IBotObserver>();

            this.Attach(botObserver);
        }

        public void Run()
        {
            Notify();
        }

        public void Attach(IBotObserver botObserver)
        {
            if (_observers.Contains(botObserver) == false)
            {
                _observers.Add(botObserver);
            }
        }

        public void Detach(IBotObserver botObserver)
        {
            _observers.Remove(botObserver);
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
    }
}
