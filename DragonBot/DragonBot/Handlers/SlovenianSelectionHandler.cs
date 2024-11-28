using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using MinimalTelegramBot.Results;
using Telegram.Bot.Types.ReplyMarkups;
using Results = MinimalTelegramBot.Results.Results;


namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class UserStatusHandler : IHandler
    {
        public async Task<IResult> HandleAsync()
        {
            var keyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
             new KeyboardButton[] { "Опция 1"},
             })
            {
                ResizeKeyboard = true,            
            };            
            return  Results.Message("Test",keyboard: keyboardMarkup);
        }
    }
}
