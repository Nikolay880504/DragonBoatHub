using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Microsoft.Extensions.DependencyInjection;
using DragonBoatHub.TelegramBot.DragonBot.Handlers;
using DragonBoatHub.TelegramBot.DragonBot.Processing;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using Refit;

namespace DragonBoatHub.TelegramBot
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

            var services = new ServiceCollection();
            services.AddTransient<UserStatusHandler>();
            services.AddTransient<SingUpHandler>();
            services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(token));
            services.AddSingleton<TelegramBotService>();
            services.AddSingleton<CommandFactory>();
            services.AddSingleton<TrainingService>();
            services.AddRefitClient<ITrainingApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288"));

            var serviceProvider = services
                .BuildServiceProvider();

            var bot = serviceProvider.GetRequiredService<TelegramBotService>();
            bot.Start();

            await Task.Delay(-1);
        }
    }
}
