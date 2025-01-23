
using Telegram.Bot.Types.ReplyMarkups;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.States;

namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class StartCommandHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;

        public StartCommandHandler(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public IResult HandleAsync()
        {            
            _stateMachine.SetState(LanguageChoiceState.state);
            var languageKeyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
              new KeyboardButton[] { "English 🇬🇧","Slovenski 🇸🇮"}
            })
            {
                ResizeKeyboard = true
            };
            
            return Results.Message("Choose your language / Izberite jezik:" , keyboard: languageKeyboardMarkup);
        }
    }
}
