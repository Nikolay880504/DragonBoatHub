
using Microsoft.Extensions.DependencyInjection;
using DragonBoatHub.TelegramBot.DragonBot.Handlers;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using Refit;
using MinimalTelegramBot.Builder;
using MinimalTelegramBot.Localization.Extensions;
using MinimalTelegramBot.Localization.Abstractions;
using DragonBot.Extensions;
using DragonBot.Handlers;
using MinimalTelegramBot.StateMachine.Extensions;

namespace DragonBoatHub.TelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = BotApplication.CreateBuilder(args);
            builder.Services.AddTransient<EnglishSelectionHandler>();
            builder.Services.AddTransient<StartCommandHandler>();
            builder.Services.AddTransient<UserStatusHandler>();
            builder.Services.AddTransient<SingUpHandler>();
            builder.Services.AddSingleLocale(
              new Locale("sl"),
               locale => locale.EnrichFromFile("Localization.yaml"));
            builder.Services.AddRefitClient<ITrainingApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288"));
            builder.Services.AddStateMachine();
            var bot = builder.Build();

            bot.UseStateMachine();
            bot.UseLocalization();
            bot.UseBotHandlers();
            bot.Run();
        }
    }
}
