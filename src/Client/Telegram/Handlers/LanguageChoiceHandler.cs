
using Telegram.Bot.Types.ReplyMarkups;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using Results = MinimalTelegramBot.Results.Results;
using DragonBot.States;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot;

namespace DragonBot.Handlers
{
    internal class LanguageChoiceHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly ITrainingApiClient _trainingApiClient;
        private readonly ILocalizer _localizer;
        private readonly IBotRequestContextAccessor _context;
       

        public LanguageChoiceHandler(IStateMachine stateMachine,
            ITrainingApiClient trainingApiClient, ILocalizer userLocale, IBotRequestContextAccessor context)
        {
            _stateMachine = stateMachine;
            _trainingApiClient = trainingApiClient;
            _localizer = userLocale;
            _context = context;
        }

        public async Task<IResult> HandleAsync()
        {

            long? userId = _context?.BotRequestContext?.Update?.Message?.From?.Id;
            if (!userId.HasValue)
            {
                Console.WriteLine("UserId is null");
                return Results.Empty;
            }

            var userLocale = _context?.BotRequestContext?.MessageText;

            await _trainingApiClient.SetUserLocationAsync(userId.Value, userLocale);


            ReplyKeyboardMarkup keyboardMarkup;
            string message;
            
            bool isRegistered = await _trainingApiClient.CheckRegistractionByTelegramIdAsync(userId.Value);
            if (isRegistered)
            {
                _stateMachine.SetState(MainMenuButtonsState.state);
                var singUpButton = _localizer["Button.SignUpForTraining"];
                keyboardMarkup = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { singUpButton } })
                {
                    ResizeKeyboard = true
                };
                message = _localizer["MessageForMainMenu"];
            }
            else
            {
                _stateMachine.SetState(SingUpState.state);
                var registrationButton = _localizer["Button.Registration"];
                keyboardMarkup = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { registrationButton } })
                {
                    ResizeKeyboard = true
                };
                message = _localizer["MessageFromRegistration"];
            }
            

            return Results.Message(message, keyboard: keyboardMarkup);

        }
    }
}

