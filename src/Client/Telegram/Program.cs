
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
using DragonBot.Localization;
using DragonBot.Localization.Interfases;

namespace DragonBoatHub.TelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = BotApplication.CreateBuilder(args);
            builder.Services.AddTransient<LanguageChoiceHandler>();
            builder.Services.AddTransient<AvailableTrainingsHandler>();
            builder.Services.AddTransient<StartCommandHandler>();
          //  builder.Services.AddSingleton<IUserLocaleProviderExtended,UserLocaleProvider>();
          //  builder.Services.AddScoped<UserLocaleLocalizer>();
            builder.Services.AddTransient<SingUpHandler>();
            builder.Services.AddSingleLocale(new Locale("sl"), locale => locale.EnrichFromFile("Localization/sl.yaml"));
            builder.Services.AddSingleLocale(new Locale("en"), locale => locale.EnrichFromFile("Localization/en.yaml"));
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
