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
    public class Test_StartObserver
    {
        [TestMethod]
        public void StartObserver_Update_UpdatesBotCommandStrategy()
        {
            // Arrange
            var expectedCommandStrategyIsNull = false;
            var expectedCommandType = CommandType.Start;

            // Initialize test CommandStrategy for NowObserver
            var testStartCommand = new ObserverTestCommand
            {
                CommandType = CommandType.Start
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testStartCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var startObserver = new StartObserver(commandStrategy);
            var testBot = new ObserverTestBot("/START", startObserver);

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
        [DataRow("/SHOWCURRLISTUA")]
        [DataTestMethod]
        public void StartObserver_Update_DoesNotUpdateBotCommandStrategy(string observerTestBotCommand)
        {
            // Arrange
            IBotStrategy expectedBotCommandStrategy = null;

            // Initialize test CommandStrategy for NowObserver
            var startCommand = new ObserverTestCommand
            {
                CommandType = CommandType.Start
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { startCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var startObserver = new StartObserver(commandStrategy);
            var testBot = new ObserverTestBot(observerTestBotCommand, startObserver);

            // Act
            testBot.Run();
            var actualBotCommandStrategy = testBot.Strategy;

            //Assert
            Assert.AreEqual(actualBotCommandStrategy, expectedBotCommandStrategy);
        }
    }
}
