using ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers;
using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Tests.Observers.ExchangeRateHandlerObservers
{
    [TestClass]
    public class Test_BYObserver
    {
        [TestMethod]
        public void BYObserver_Update_UpdatesExchangeRateHandlerStrategy()
        {
            // Arrange
            string expectedTypeOfStrategy = "BYExchangeRateHandlerStrategy";

            List<IExchangeRateHandlerObserver> availableObservers = new List<IExchangeRateHandlerObserver>
            {
                new BYObserver()
            };

            var exchangeRatehandler = new ObserverTestExchangeRateHandler(availableObservers);

            // Act
            exchangeRatehandler.SetNewRequest("@test /test USD 1996-01-01 BY");
            exchangeRatehandler.GetExchangeRate();

            var actualTypeOfStrategy = exchangeRatehandler.Strategy.GetType().Name;

            // Assert
            Assert.AreEqual(expectedTypeOfStrategy, actualTypeOfStrategy);
        }

        [DataRow("@test /test USD 2010-01-01 UA", null)]
        [DataTestMethod]
        public void BYObserver_Update_DoesNotUpdateExchangeRateHandlerStrategy(string inputMessage, IExchangeRateHandlerStrategy expectedStrategy)
        {
            // Arrange
            List<IExchangeRateHandlerObserver> availableObservers = new List<IExchangeRateHandlerObserver>
            {
                new BYObserver()
            };

            var exchangeRatehandler = new ObserverTestExchangeRateHandler(availableObservers);

            // Act
            exchangeRatehandler.SetNewRequest(inputMessage);
            exchangeRatehandler.GetExchangeRate();

            var actualStrategy = exchangeRatehandler.Strategy;

            // Assert
            Assert.AreEqual(actualStrategy, expectedStrategy);
        }
    }
}
