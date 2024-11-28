
using Telegram.Bot.Types.ReplyMarkups;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;

namespace DragonBot.Handlers
{
    internal class LanguageSelectionHandler : IHandler
    {
        public async Task<IResult> HandleAsync()
        {
            var keyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
             new KeyboardButton[] { "English 🇬🇧","Slovenski 🇸🇮"},
             })
            {
                ResizeKeyboard = true,
            };
            return Results.Message("ssss", keyboard: keyboardMarkup);
        }
    }
}
