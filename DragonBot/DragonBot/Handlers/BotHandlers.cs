
using Telegram.Bot.Types;
using Telegram.Bot;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types.Enums;
using System;

namespace DragonBot.Handlers
{
    internal class BotHandlers
    {
        internal static async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {

        }

        internal static async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var chat = update.Message.Chat;

            switch (update.Type)
            {

                case UpdateType.Message:
                case UpdateType.CallbackQuery:
                    var messageText = update.Type == UpdateType.Message
                        ? update.Message.Text
                        : update.CallbackQuery.Data;

                    switch (messageText)
                    {
                        case "/start":
                            await client.SendTextMessageAsync(
                                   chat.Id,
                                  "/start");

                            break;
                    }


                    break;

                default:

                    break;
            }

        }
    }
}
