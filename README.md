# exchange_rate_bot
A simple telegram bot that can help you to get exchange rate records from Belarusian and Ukrainian national bank archives by calling their Web APIs.

# Description:

This application has the following architecture:

- Presentation layer: Console Application (C#, .NET Core);
- Business layer: Class Library (C#, .NET Core).

There are some additional project details (architecture, technologies/patterns used, etc.):
- Telegram.Bot Library for Telegram API (https://github.com/TelegramBots/Telegram.Bot);
- Public Web API calls (Asp.Net.WebApi.Client);
- Dependency injection (.NET dependency injection);
- Logging (Serilog, configurations, sinks: debug, txt-file);
- JSON parsing (Newtonsoft.Json);
- Application configuration (hosting, services, appsettings.json);
- Asynchronous programming;
- User secrets;
- Command pattern;
- Strategy pattern;
- Observer pattern;
- Unit-testing (MSTest).

Tools used:
- Postman;
- Telerik Fiddler Web Debugger.


# Demo:

![](demo.gif)
