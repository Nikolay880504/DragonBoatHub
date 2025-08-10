using Telegram.Bot.Types.ReplyMarkups;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.States;
using DragonBot.Localization.Interfases;
using DragonBot.States;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot;

namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class StartCommandHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly IEnumerable<ISupportedLocale> _supportedLocales;
        private readonly IUserTrainingApiClient _trainingApiClient;
        private readonly ILocalizer _localizer;
        private readonly IBotRequestContextAccessor _context;

        public StartCommandHandler(ILocalizer localizer, IUserTrainingApiClient trainingApiClient,
            IStateMachine stateMachine, IEnumerable<ISupportedLocale> supportedLocales, IBotRequestContextAccessor context)
        {
            _stateMachine = stateMachine;
            _supportedLocales = supportedLocales;
            _localizer = localizer;
            _trainingApiClient = trainingApiClient;
            _context = context;
        }
        public async Task<IResult> HandleAsync()
        {
            var userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;

            ReplyKeyboardMarkup keyboardMarkup;
            string message;

            var isRegistered = await _trainingApiClient.CheckRegistractionByTelegramIdAsync(userId);
            if (isRegistered)
            {
                _stateMachine.SetState(MainMenuButtonsState.State);
                var singUpButton = _localizer["Button.MainMenu"];
                keyboardMarkup = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { singUpButton } })
                {
                    ResizeKeyboard = true
                };
                message = _localizer["MessageForMainMenu"];
            }
            else
            {
                _stateMachine.SetState(LanguageChoiceState.State);

                var languageKeyboardMarkup = new ReplyKeyboardMarkup(
                _supportedLocales.Select(locale => new KeyboardButton(locale.NameButton)).ToArray())

                {
                    ResizeKeyboard = true
                };
                return Results.Message(string.Join(" / ", _supportedLocales.Select(locale => locale.Message)),
                                  keyboard: languageKeyboardMarkup);
            }
            return Results.Message(message, keyboard: keyboardMarkup);
        }
    }
}
