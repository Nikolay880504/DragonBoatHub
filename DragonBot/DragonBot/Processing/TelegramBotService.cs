
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
using DragonBot.Handlers;


namespace DragonBot.TelegramBot
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
