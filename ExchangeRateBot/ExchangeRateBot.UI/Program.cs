using ExchangeRateBot.Library.Commands;
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

            Log.Logger.Information("Application starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IBot, Bot>();
                    services.AddTransient<IExchangeRateMessageValidator, ExchangeRateMessageValidator>();
                    services.AddTransient<IExchangeRateHandler, ExchangeRateHandler>();
                    services.AddTransient<IExchangeRateCommand, ExchangeRateCommand>();
                    services.AddTransient<IShowCurrListBY, ShowCurrListBY>();
                    services.AddTransient<IShowCurrListUA, ShowCurrListUA>();
                    services.AddTransient<IStartCommand, StartCommand>();
                    services.AddTransient<INowCommand, NowCommand>();
                    services.AddTransient<IHelpCommand, HelpCommand>();
                    services.AddTransient<IChatMessageSender, ChatMessageSender>();
                })
                .UseSerilog()
                .Build();

            ApiHandler.InitializeApiClient();
            BotSettings.BotToken = builder.Build().GetValue<string>("BotApiToken");

            var bot = ActivatorUtilities.CreateInstance<Bot>(host.Services);
            bot.Run();
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
