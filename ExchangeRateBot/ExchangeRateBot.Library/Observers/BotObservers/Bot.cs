using ExchangeRateBot.Library;
using ExchangeRateBot.Library.Observers;
using ExchangeRateBot.Library.Strategy;
using ExchangeRateBot.Library.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ExchangeRateBot.UI
{
    /// <summary>
    /// Represents a telegram bot.
    /// </summary>
    public class Bot : IBot, IBotSubject
    {
        private ITelegramBotClient _botClient;
        private readonly IChatMessageSender _chatMessageSender;
        private readonly IEnumerable<IBotObserver> _availableObservers;
        private List<IBotObserver> _observers;

        public IBotStrategy Strategy { get; set; }
        public string Command { get; set; }

        public Bot(IChatMessageSender chatMessageSender, IEnumerable<IBotObserver> availableObservers)
        {
            _chatMessageSender = chatMessageSender;
            _observers = new List<IBotObserver>();
            _availableObservers = availableObservers;

            AttachObservers();
        }
        
        public void Run()
        {
            InitializeBotClient();
            InitializeWelcomeSequence();

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.OnMessageEdited += _botClient_OnMessageEdited;
            _botClient.StartReceiving(Array.Empty<UpdateType>());

            InitializeFinishSequence();

            _botClient.StopReceiving();
        }

        void _botClient_OnMessageEdited(object sender, Telegram.Bot.Args.MessageEventArgs e) => _botClient_OnMessage(sender, e);

        async void _botClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Log.Information("Bot recieved a message.");

            var message = e.Message;
            var messageElements = message.Text.ToUpper().Split(' ');
            var botName = BotSettings.Name;

            if (messageElements.First() == $"@{ botName }")
            {
                Command = messageElements[1];
                Notify();

                if (Strategy != null)
                {
                    await Strategy.ExecuteAsync(message, _botClient);
                    Log.Information($"{Command} command was executed successfully.");

                    Strategy = null;
                }
                else
                {
                    await _chatMessageSender.SendUnrecognizedCommandMessageAsync(message, _botClient);
                    Log.Error("Unrecognized command.");
                }
            }
        }

        public void Attach(IBotObserver botObserver)
        {
            if (_observers.Contains(botObserver) == false)
            {
                _observers.Add(botObserver);
            }
        }

        public void Detach(IBotObserver botObserver)
        {
            if (_observers.Contains(botObserver))
            {
                _observers.Remove(botObserver);
            }
        }

        public void Notify()
        {
            if (_observers.Count > 0)
            {
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }

        private void AttachObservers()
        {
            foreach (var observer in _availableObservers)
            {
                if (_observers.Contains(observer) == false)
                {
                    _observers.Add(observer);
                }
            }
        }

        private void InitializeBotClient()
        {
            if (_botClient == null)
            {
                _botClient = new TelegramBotClient(BotSettings.BotToken)
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };
            }
        }

        private void InitializeWelcomeSequence()
        {
            var me = _botClient.GetMeAsync().Result;
            Log.Information("Bot client acquired.");

            Console.WriteLine(
              $"Hello! I am user {me.Id} and my name is {me.FirstName}."
            );

            Console.Title = me.Username;
            BotSettings.Name = me.FirstName.ToUpper();
        }

        private void InitializeFinishSequence()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
