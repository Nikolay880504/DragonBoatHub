using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace DragonBot
{
    internal class Program
    {
        private static readonly string token;


        static Program()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            token = configuration["BotSettings:Token"]!;
        }

        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient(token);

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[] { UpdateType.Message, UpdateType.CallbackQuery }, 
                ThrowPendingUpdates = true 
            };

            botClient.StartReceiving(
                Handlers.BotHandlers.HandleUpdateAsync,
                Handlers.BotHandlers.HandleErrorAsync,
                receiverOptions
            );
            await Task.Delay(-1);
        }

       
    }

}
