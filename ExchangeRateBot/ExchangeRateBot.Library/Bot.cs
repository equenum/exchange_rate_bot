using ExchangeRateBot.Library.Commands;
using ExchangeRateBot.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot
{
    public class Bot : IBot
    {
        // TODO: XML-comments
        // TODO: Update Help command result; add BYR (2016) and RUR (1998) notification
        // TODO: Unit-tests
        // TODO: Logging
        // TODO: Factory

        private ITelegramBotClient _botClient;
        private List<ICommand> _commands = new List<ICommand>();
        private IExchangeRateCommand _exchangeRateCommand;
        private readonly IChatMessageSender _chatMessageSender;
        private readonly IShowCurrListBY _showCurrListBY;
        private readonly IShowCurrListUA _showCurrListUA;
        private readonly IStartCommand _startCommand;
        private readonly INowCommand _nowCommand;
        private readonly IHelpCommand _helpCommand;

        public Bot(
            IExchangeRateCommand exchangeRateCommand, 
            IShowCurrListBY showCurrListBY, 
            IShowCurrListUA showCurrListUA, 
            IStartCommand startCommand, 
            INowCommand nowCommand, 
            IHelpCommand helpCommand,
            IChatMessageSender chatMessageSender)
        {
            _exchangeRateCommand = exchangeRateCommand;
            _chatMessageSender = chatMessageSender;
            _showCurrListBY = showCurrListBY;
            _showCurrListUA = showCurrListUA;
            _startCommand = startCommand;
            _nowCommand = nowCommand;
            _helpCommand = helpCommand;
        }

        public void Run()
        {
            if (_botClient == null)
            {
                _botClient = new TelegramBotClient(BotSettings.BotToken)
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };
            }

            AddCommands();

            var me = _botClient.GetMeAsync().Result;

            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            Console.Title = me.Username;
            BotSettings.Name = me.FirstName.ToUpper();

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.OnMessageEdited += _botClient_OnMessageEdited;

            _botClient.StartReceiving(Array.Empty<UpdateType>());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();

            void _botClient_OnMessageEdited(object sender, Telegram.Bot.Args.MessageEventArgs e) => _botClient_OnMessage(sender, e);

            async void _botClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
            {
                var message = e.Message;
                bool unrecognizedCommand = true;

                foreach (var command in _commands)
                {
                    if (command.Contains(message.Text.ToUpper()))
                    {
                        await command.Execute(message, _botClient);
                        unrecognizedCommand = false;
                    }
                }

                if (unrecognizedCommand == true)
                {
                    await _chatMessageSender.SendUnrecognizedCommandMessage(message, _botClient);
                }
            }

            void AddCommands()
            {
                _commands.Add(_helpCommand);
                _commands.Add(_nowCommand);
                _commands.Add(_exchangeRateCommand);
                _commands.Add(_showCurrListBY);
                _commands.Add(_showCurrListUA);
                _commands.Add(_startCommand);
            }
        }
    }
}
