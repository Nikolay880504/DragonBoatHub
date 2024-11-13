
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
using DragonBoatHub.TelegramBot.DragonBot.Handlers;


namespace DragonBoatHub.TelegramBot.DragonBot.Processing
{

    internal class TelegramBotService
    {
        private readonly ITelegramBotClient _client;
        private readonly CommandFactory _factory;

        public TelegramBotService(ITelegramBotClient client, CommandFactory factory)
        {
            _client = client;
            _factory = factory;
        }

        public void Start()
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[] { UpdateType.Message, UpdateType.CallbackQuery },
                ThrowPendingUpdates = true
            };

            _client.StartReceiving(
                 HandleUpdateAsync,
                 HandleErrorAsync,
                 receiverOptions
            );
        }
        private async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            // Логирование сообщения об ошибке
            Console.WriteLine($"Error: {exception.Message}");

            // Логирование стека вызовов для подробной информации о месте ошибки
            Console.WriteLine($"Stack Trace: {exception.StackTrace}");

            // Если есть внутреннее исключение, логируем его также
            if (exception.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {exception.InnerException.Message}");
                Console.WriteLine($"Inner Exception Stack Trace: {exception.InnerException.StackTrace}");
            }

            // Дополнительно, вы можете логировать тип исключения
            Console.WriteLine($"Exception Type: {exception.GetType().FullName}");

        }


        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {

            var messageText = update.Type == UpdateType.Message
                ? update.Message?.Text ?? string.Empty
                : update.CallbackQuery?.Data ?? string.Empty;

            var handler = _factory.GetRequiredHendler(messageText);
            await handler.HandleAsync(update, client);

        }
    }
}
