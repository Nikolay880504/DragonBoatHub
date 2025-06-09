using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Telegram.Bot.Types.ReplyMarkups;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.StateMachine.Abstractions;
using DragonBot.States;


namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class RequestPhoneNumberHandler : IHandler
    {
        private readonly ILocalizer _localizer;
        private readonly IStateMachine _stateMachine;
        public RequestPhoneNumberHandler(ILocalizer localizer, IStateMachine stateMachine)
        {
            _localizer = localizer;
            _stateMachine = stateMachine;
        }

        public IResult HandleAsync()
        {
            _stateMachine.SetState(RequestFirstNameState.state);
            KeyboardButton button = KeyboardButton.WithRequestContact(_localizer["Button.SendContact"]);  

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(button);

            return Results.Message(_localizer["PleaseSendContact"], keyboard);
        }
    }
}
