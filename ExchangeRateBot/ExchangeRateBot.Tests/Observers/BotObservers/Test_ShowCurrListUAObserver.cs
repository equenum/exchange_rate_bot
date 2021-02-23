using ExchangeRateBot.Library.Commands;
using ExchangeRateBot.Library.Observers;
using ExchangeRateBot.Library.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateBot.Tests.Observers
{
    [TestClass]
    public class Test_ShowCurrListUAObserver
    {
        [TestMethod]
        public void ShowCurrListUAObserver_Update_UpdatesBotCommandStrategy()
        {
            // Arrange
            var expectedCommandStrategyIsNull = false;
            var expectedCommandType = CommandType.ShowCurrListUA;

            // Initialize test CommandStrategy for NowObserver
            var testShowCurrListUACommand = new ObserverTestCommand
            {
                CommandType = CommandType.ShowCurrListUA
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testShowCurrListUACommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var showCurrListUAObserver = new ShowCurrListUAObserver(commandStrategy);
            var testBot = new ObserverTestBot("/SHOWCURRLISTUA", showCurrListUAObserver);

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

        [DataRow("/EXCHANGERATE")]
        [DataRow("/NOW")]
        [DataRow("/HELP")]
        [DataRow("/SHOWCURRLISTBY")]
        [DataRow("/START")]
        [DataTestMethod]
        public void ShowCurrListUAObserver_Update_DoesNotUpdateBotCommandStrategy(string observerTestBotCommand)
        {
            // Arrange
            IBotStrategy expectedBotCommandStrategy = null;

            // Initialize test CommandStrategy for NowObserver
            var showCurrListUACommand = new ObserverTestCommand
            {
                CommandType = CommandType.ShowCurrListUA
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { showCurrListUACommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var showCurrListUAObserver = new ShowCurrListUAObserver(commandStrategy);
            var testBot = new ObserverTestBot(observerTestBotCommand, showCurrListUAObserver);

            // Act
            testBot.Run();
            var actualBotCommandStrategy = testBot.Strategy;

            //Assert
            Assert.AreEqual(actualBotCommandStrategy, expectedBotCommandStrategy);
        }
    }
}
