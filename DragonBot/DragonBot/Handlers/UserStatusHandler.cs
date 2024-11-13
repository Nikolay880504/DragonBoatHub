using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class UserStatusHandler : IHandler
    {
        public async Task HandleAsync(Update update, ITelegramBotClient client)
        {
            if (update.Message?.Chat?.Id == null)
            {
                Console.WriteLine("Chat ID is null. Unable to send message.");
                return;
            }

            var chatId = update.Message.Chat.Id;

            InlineKeyboardMarkup inlineKeyboard;
            if (false) { 
            inlineKeyboard = new InlineKeyboardMarkup(new[]
           {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Register", "register")
            }
        });
                await client.SendTextMessageAsync(chatId, "Welcome! Please register:", replyMarkup: inlineKeyboard);
            }
            if (true)
            {
                inlineKeyboard = new InlineKeyboardMarkup(new[]
          {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Sign Up", "singup")
            }
        });
            }
            await client.SendTextMessageAsync(chatId, "Welcome! Please choose an action:", replyMarkup: inlineKeyboard);
        }
    }
}
