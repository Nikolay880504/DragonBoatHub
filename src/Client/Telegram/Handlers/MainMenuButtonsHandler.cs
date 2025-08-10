using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Results = MinimalTelegramBot.Results.Results;
using Telegram.Bot.Types.ReplyMarkups;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.Results;

namespace DragonBot.Handlers
{
    class MainMenuButtonsHandler : IHandler
    {
        private readonly ILocalizer _localizer;

        public MainMenuButtonsHandler(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public IResult Handle()
        { 
            var replyKeyBoard = new ReplyKeyboardMarkup(new[] 
            
            { new KeyboardButton(_localizer["Button.SignUpForTraining"]) })
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            return Results.Message(_localizer["InnerMainMenu"], replyKeyBoard) ;
        }
    }
}
