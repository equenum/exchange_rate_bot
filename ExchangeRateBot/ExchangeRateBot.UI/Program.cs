using ExchangeRateBot.Library;
using ExchangeRateBot.Library.Commands;
using ExchangeRateBot.Library.Observers;
using ExchangeRateBot.Library.Observers.ExchangeRateHandlerObservers;
using ExchangeRateBot.Library.Observers.ExchangeRateObservers;
using ExchangeRateBot.Library.Strategy;
using ExchangeRateBot.Library.Utilities;
using ExchangeRateBot.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace ExchangeRateBot.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started.");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Utilities
                    services.AddTransient<IExchangeRateMessageValidator, ExchangeRateMessageValidator>();
                    services.AddTransient<IChatMessageSender, ChatMessageSender>();

                    // Bot strategy + commands
                    services.AddTransient<IBotStrategy, BotStrategy>();
                    services.AddTransient<ICommand, ExchangeRateCommand>();
                    services.AddTransient<ICommand, ShowCurrListBYCommand>();
                    services.AddTransient<ICommand, ShowCurrListUACommand>();
                    services.AddTransient<ICommand, StartCommand>();
                    services.AddTransient<ICommand, NowCommand>();
                    services.AddTransient<ICommand, HelpCommand>();

                    // Bot + bot observers
                    services.AddTransient<IBot, Bot>();
                    services.AddTransient<IBotObserver, HelpObserver>();
                    services.AddTransient<IBotObserver, NowObserver>();
                    services.AddTransient<IBotObserver, StartObserver>();
                    services.AddTransient<IBotObserver, ExchangeRateObserver>();
                    services.AddTransient<IBotObserver, ShowCurrListBYObserver>();
                    services.AddTransient<IBotObserver, ShowCurrListUAObserver>();

                    // ExchangeRateHandler + observers
                    services.AddTransient<IExchangeRateHandler, ExchangeRateHandler>();
                    services.AddTransient<IExchangeRateHandlerObserver, BYObserver>();
                    services.AddTransient<IExchangeRateHandlerObserver, UAObserver>();
                })
                .UseSerilog()
                .Build();

            ApiHandler.InitializeApiClient();
            BotSettings.BotToken = builder.Build().GetValue<string>("BotApiToken");

            var bot = ActivatorUtilities.CreateInstance<Bot>(host.Services);
            bot.Run();

            Log.Information("Application finished.");
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings." +
                    $"{ Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
