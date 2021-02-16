using ExchangeRateBot.Library.Commands;
using ExchangeRateBot.Library.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.UI
{
    /// <summary>
    /// Representa a telegram bot.
    /// </summary>
    public class Bot : IBot
    {
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
            Log.Information("Bot client acquired.");

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
                Log.Information("Bot recieved a message.");

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

                    Log.Error("Unrecognized command.");
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
