using ExchangeRateBot.Library.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot
{
    public class Bot : IBot
    {
        // TODO: No data notification
        private TelegramBotClient _botClient;
        private List<ICommand> _commands = new List<ICommand>(); // rename later

        //public IReadOnlyList<ICommand> Commands { get => CommandsList.AsReadOnly(); }

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

            //Console.WriteLine($"Start listening for @{me.Username}"); // TODO: What is that?

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();

            void _botClient_OnMessageEdited(object sender, Telegram.Bot.Args.MessageEventArgs e) => _botClient_OnMessage(sender, e);

            async void _botClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
            {
                var message = e.Message;

                foreach (var command in _commands)
                {
                    if (command.Contains(message.Text.ToUpper()))
                    {
                        await command.Execute(message, _botClient);
                    }
                }
            }

            void AddCommands()
            {
                _commands.Add(new TestCommand()); // TODO: Delete later
                _commands.Add(new NowCommand()); // TODO: Extract a method for that
                _commands.Add(new HelpCommand());
                _commands.Add(new ExchangeRateCommand());
            }
        }
    }
}
