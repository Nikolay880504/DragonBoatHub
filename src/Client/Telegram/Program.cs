
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
using Microsoft.Extensions.DependencyInjection.Extensions;
using DragonBot.Localization.Interfases;
namespace DragonBoatHub.TelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var supportedLocales = new SupportedLocale[]
            {
                new SupportedLocale()
                {
                    PathToFile = "Localization/sl.yaml",
                    Code ="sl",
                    NameButton = "Slovenski 🇸🇮",
                    Message = "Izberite jezik:"
                },
                new SupportedLocale()
                {
                    PathToFile = "Localization/en.yaml",
                    Code ="en",
                    NameButton = "English 🇬🇧",
                    Message = "Choose your language:"
                }
            };
           
            var builder = BotApplication.CreateBuilder(args);

            foreach (var supportedLocale in supportedLocales)
            {
                builder.Services.AddSingleton<ISupportedLocale>(supportedLocale);
            }

            builder.Services.AddTransient<LanguageChoiceHandler>();
            builder.Services.AddTransient<AvailableTrainingsHandler>();
            builder.Services.AddTransient<StartCommandHandler>();
            builder.Services.AddTransient<SingUpHandler>();
            builder.Services.AddSingleton<IUserLocaleCache, UserLocaleCache>();
            RegisterLocalization(builder.Services, supportedLocales);
            builder.Services.AddRefitClient<ITrainingApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288"));
            builder.Services.AddStateMachine();
            var bot = builder.Build();
            bot.UseStateMachine();
            bot.UseLocalization();
            bot.UseBotHandlers();
            
            bot.Run();
        }

        private static void RegisterLocalization(IServiceCollection services, SupportedLocale[] locales)
        {            
            services.AddLocalizer<UserLocaleProvider>( builder =>
            {
                builder.AddLocale(new Locale(locales[0].Code)).EnrichFromFile(locales[0].PathToFile);
                builder.AddLocale(new Locale(locales[1].Code)).EnrichFromFile(locales[1].PathToFile);
            });  
            
        }
    }
}
