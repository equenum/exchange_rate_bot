using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Tests.Utilities
{
    [TestClass]
    public class Test_ExchangeRateHandler
    {
        [DataRow("@test /test USD 2020-01-01 BY", "USD", "BY", 2020, 01, 01)]
        [DataRow("@test /test USD 2020-01-01 UA", "USD", "UA", 2020, 01, 01)]
        [DataTestMethod]
        public void ExchangeRateHandler_SetNewRequest_CountryIsSpecified(
            string inputMessage, string expectedCurrency, string expectedCountry, 
            int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var availableObservers = new List<IExchangeRateHandlerObserver>();
            var exchangeRateHandler = new ExchangeRateHandler(availableObservers);

            // Act
            exchangeRateHandler.SetNewRequest(inputMessage);

            var actualCurrency = exchangeRateHandler.Request.Currency;
            var actualCountry = exchangeRateHandler.Request.Country;
            var actualYear = exchangeRateHandler.Request.Date.Year;
            var actualMonth = exchangeRateHandler.Request.Date.Month;
            var actualDay = exchangeRateHandler.Request.Date.Day;

            // Assert
            Assert.AreEqual(actualCurrency, expectedCurrency);
            Assert.AreEqual(actualCountry, expectedCountry);
            Assert.AreEqual(actualYear, expectedYear);
            Assert.AreEqual(actualMonth, expectedMonth);
            Assert.AreEqual(actualDay, expectedDay);
        }

        [DataRow("@test /test USD 2020-01-01", "USD", "UA", 2020, 01, 01)]
        [DataTestMethod]
        public void ExchangeRateHandler_SetNewRequest_CountryIsNotSpecified(
            string inputMessage, string expectedCurrency, string expectedCountry,
            int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var availableObservers = new List<IExchangeRateHandlerObserver>();
            var exchangeRateHandler = new ExchangeRateHandler(availableObservers);

            // Act
            exchangeRateHandler.SetNewRequest(inputMessage);

            var actualCurrency = exchangeRateHandler.Request.Currency;
            var actualCountry = exchangeRateHandler.Request.Country;
            var actualYear = exchangeRateHandler.Request.Date.Year;
            var actualMonth = exchangeRateHandler.Request.Date.Month;
            var actualDay = exchangeRateHandler.Request.Date.Day;

            // Assert
            Assert.AreEqual(actualCurrency, expectedCurrency);
            Assert.AreEqual(actualCountry, expectedCountry);
            Assert.AreEqual(actualYear, expectedYear);
            Assert.AreEqual(actualMonth, expectedMonth);
            Assert.AreEqual(actualDay, expectedDay);
        }
    }
}
