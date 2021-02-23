using ExchangeRateBot.Library.Commands;
using ExchangeRateBot.Library.Observers;
using ExchangeRateBot.Library.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ExchangeRateBot.Tests.Observers
{
    [TestClass]
    public class Test_HelpObserver
    {
        [TestMethod]
        public void HelpObserver_Update_UpdatesBotCommandStrategy()
        {
            // Arrange
            var expectedCommandStrategyIsNull = false;
            var expectedCommandType = CommandType.Help;

            // Initialize test CommandStrategy for NowObserver
            var testHelpCommand = new ObserverTestCommand
            {
                CommandType = CommandType.Help
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { testHelpCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var helpObserver = new HelpObserver(commandStrategy);
            var testBot = new ObserverTestBot("/HELP", helpObserver);

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
        [DataRow("/START")]
        [DataRow("/SHOWCURRLISTBY")]
        [DataRow("/SHOWCURRLISTUA")]
        [DataTestMethod]
        public void HelpObserver_Update_DoesNotUpdateBotCommandStrategy(string observerTestBotCommand)
        {
            // Arrange
            IBotStrategy expectedBotCommandStrategy = null;

            // Initialize test CommandStrategy for NowObserver
            var helpCommand = new ObserverTestCommand
            {
                CommandType = CommandType.Help
            };

            IEnumerable<ICommand> commands = new List<ICommand>() { helpCommand };
            var commandStrategy = new BotStrategy(commands);

            // Initialize the test bot
            var helpObserver = new HelpObserver(commandStrategy);
            var testBot = new ObserverTestBot(observerTestBotCommand, helpObserver);

            // Act
            testBot.Run();
            var actualBotCommandStrategy = testBot.Strategy;

            //Assert
            Assert.AreEqual(actualBotCommandStrategy, expectedBotCommandStrategy);
        }
    }
}
