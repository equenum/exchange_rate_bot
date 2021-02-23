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
    public class Test_ShowCurrListBYObserver
    {
        [TestMethod]
        public void ShowCurrListBYObserver_Update_UpdatesBotCommandStrategy()
        {
            // Arrange
            var expectedCommandStrategyIsNull = false;
            var expectedCommandType = CommandType.ShowCurrListBY;

            // Initialize test CommandStrategy for NowObserver
            var testShowCurrListBYCommand = new ObserverTestCommand
            {
                CommandType = CommandType.ShowCurrListBY
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testShowCurrListBYCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var showCurrListBYObserver = new ShowCurrListBYObserver(commandStrategy);
            var testBot = new ObserverTestBot("/SHOWCURRLISTBY", showCurrListBYObserver);

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
        [DataRow("/SHOWCURRLISTUA")]
        [DataRow("/START")]
        [DataTestMethod]
        public void ShowCurrListBYObserver_Update_DoesNotUpdateBotCommandStrategy(string observerTestBotCommand)
        {
            // Arrange
            IBotStrategy expectedBotCommandStrategy = null;

            // Initialize test CommandStrategy for NowObserver
            var showCurrListBYCommand = new ObserverTestCommand
            {
                CommandType = CommandType.ShowCurrListBY
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { showCurrListBYCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var showCurrListBYObserver = new ShowCurrListBYObserver(commandStrategy);
            var testBot = new ObserverTestBot(observerTestBotCommand, showCurrListBYObserver);

            // Act
            testBot.Run();
            var actualBotCommandStrategy = testBot.Strategy;

            //Assert
            Assert.AreEqual(actualBotCommandStrategy, expectedBotCommandStrategy);
        }
    }
}
