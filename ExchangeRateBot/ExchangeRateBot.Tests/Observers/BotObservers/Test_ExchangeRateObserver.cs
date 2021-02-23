using ExchangeRateBot.Library.Commands;
using ExchangeRateBot.Library.Observers;
using ExchangeRateBot.Library.Strategy;
using ExchangeRateBot.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Tests.Observers
{
    [TestClass]
    public class Test_ExchangeRateObserver
    {
        [TestMethod]
        public void ExchangeRateObserver_Update_UpdatesBotCommandStrategy()
        {
            // Arrange
            var expectedCommandStrategyIsNull = false;
            var expectedCommandType = CommandType.ExchangeRate;

            // Initialize test CommandStrategy for ExchangeRateObserver
            var testExchangeRateCommand = new ObserverTestCommand
            {
                CommandType = CommandType.ExchangeRate
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testExchangeRateCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var exchangeRateObserver = new ExchangeRateObserver(commandStrategy);
            var testBot = new ObserverTestBot("/EXCHANGERATE", exchangeRateObserver);

            // Act
            testBot.Run();
            var actualCommandStrategyIsNull = testBot.Strategy == null;

            CommandType? actualCommandType = null; 

            if (actualCommandStrategyIsNull == false)
            {
                actualCommandType = testBot.Strategy.CommandType;
            }

            //Assert
            Assert.AreEqual(actualCommandStrategyIsNull, expectedCommandStrategyIsNull);

            if (actualCommandStrategyIsNull == false)
            {
                Assert.AreEqual(actualCommandType, expectedCommandType);
            }
        }

        [DataRow("/NOW")]
        [DataRow("/HELP")]
        [DataRow("/START")]
        [DataRow("/SHOWCURRLISTBY")]
        [DataRow("/SHOWCURRLISTUA")]
        [DataTestMethod]
        public void ExchangeRateObserver_Update_DoesNotUpdateBotCommandStrategy(string observerTestBotCommand)
        {
            // Arrange
            IBotStrategy expectedBotCommandStrategy = null;

            // Initialize test CommandStrategy for ExchangeRateObserver
            var testExchangeRateCommand = new ObserverTestCommand
            {
                CommandType = CommandType.ExchangeRate
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testExchangeRateCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var exchangeRateObserver = new ExchangeRateObserver(commandStrategy);
            var testBot = new ObserverTestBot(observerTestBotCommand, exchangeRateObserver);

            // Act
            testBot.Run();
            var actualBotCommandStrategy = testBot.Strategy;

            //Assert
            Assert.AreEqual(actualBotCommandStrategy, expectedBotCommandStrategy);
        }
    }
}
