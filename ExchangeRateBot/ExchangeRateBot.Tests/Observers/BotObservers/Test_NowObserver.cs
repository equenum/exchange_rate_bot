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
    public class Test_NowObserver
    {
        [TestMethod]
        public void NowObserver_Update_UpdatesBotCommandStrategy()
        {
            // Arrange
            var expectedCommandStrategyIsNull = false;
            var expectedCommandType = CommandType.Now;

            // Initialize test CommandStrategy for NowObserver
            var testNowCommand = new ObserverTestCommand
            {
                CommandType = CommandType.Now
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testNowCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var nowObserver = new NowObserver(commandStrategy);
            var testBot = new ObserverTestBot("/NOW", nowObserver);

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
        [DataRow("/HELP")]
        [DataRow("/START")]
        [DataRow("/SHOWCURRLISTBY")]
        [DataRow("/SHOWCURRLISTUA")]
        [DataTestMethod]
        public void NowObserver_Update_DoesNotUpdateBotCommandStrategy(string observerTestBotCommand)
        {
            // Arrange
            IBotStrategy expectedBotCommandStrategy = null;

            // Initialize test CommandStrategy for NowObserver
            var nowCommand = new ObserverTestCommand
            {
                CommandType = CommandType.Now
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { nowCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var nowObserver = new NowObserver(commandStrategy);
            var testBot = new ObserverTestBot(observerTestBotCommand, nowObserver);

            // Act
            testBot.Run();
            var actualBotCommandStrategy = testBot.Strategy;

            //Assert
            Assert.AreEqual(actualBotCommandStrategy, expectedBotCommandStrategy);
        }
    }
}
