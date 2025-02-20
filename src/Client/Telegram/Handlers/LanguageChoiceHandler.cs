
using Telegram.Bot.Types.ReplyMarkups;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using Results = MinimalTelegramBot.Results.Results;
using DragonBot.States;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot;
using DragonBot.Localization.Interfases;

namespace DragonBot.Handlers
{
    internal class LanguageChoiceHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly ITrainingApiClient _trainingApiClient;
        private readonly ILocalizer _localizer;
        private readonly IBotRequestContextAccessor _context;
        private readonly IEnumerable<ISupportedLocale> _supportedLocales;
        private readonly IUserLocaleCache _userLocaleCache;


        public LanguageChoiceHandler(IStateMachine stateMachine,
            ITrainingApiClient trainingApiClient, ILocalizer userLocale, IBotRequestContextAccessor context
, IEnumerable<ISupportedLocale> supportedLocales, IUserLocaleCache userLocaleCache)
        {
            _stateMachine = stateMachine;
            _trainingApiClient = trainingApiClient;
            _localizer = userLocale;
            _context = context;
            _supportedLocales = supportedLocales;
            _userLocaleCache = userLocaleCache;

        }

        public async Task<IResult> HandleAsync()
        {

            long userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;

            var textButton = _context!.BotRequestContext!.MessageText;

            var locale = _supportedLocales.FirstOrDefault(locale => locale.NameButton == textButton);

            if (locale != null)
            {
                _userLocaleCache.UpdateLocalCache(userId, locale.Code);
                _context!.BotRequestContext!.UserLocale = new Locale(locale.Code);
                await _trainingApiClient.SetUserLocalizationAsync(userId, locale.Code);
            }

            ReplyKeyboardMarkup keyboardMarkup;
            string message;

            bool isRegistered = await _trainingApiClient.CheckRegistractionByTelegramIdAsync(userId);
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

