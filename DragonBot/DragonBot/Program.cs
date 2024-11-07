using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Microsoft.Extensions.DependencyInjection;
using DragonBot.Handlers.Interfaces;
using DragonBot.Handlers;
using DragonBot.TelegramBot;

namespace DragonBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            var token = configuration["BotSettings:Token"]!;

            var serviceProvider = new ServiceCollection()
                .AddTransient<UserStatusHandler>()
                .AddTransient<SingUpHandler>()
                .AddSingleton<ITelegramBotClient>(new TelegramBotClient(token))
                .AddSingleton<TelegramBotService>()
                .AddSingleton<CommandFactory>()
                .BuildServiceProvider();

            var bot = serviceProvider.GetRequiredService<TelegramBotService>();
            bot.Start();

            await Task.Delay(-1);
        }

    }

}
