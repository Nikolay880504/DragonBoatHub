using DragonBoatHub.Contracts;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using DragonBot.States;
using MinimalTelegramBot;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;
using Results = MinimalTelegramBot.Results.Results;

namespace DragonBot.Handlers
{
    class UserRegistrationStatusHandler : IHandler
    {
        private readonly IBotRequestContextAccessor _context;
        private readonly IUserTrainingApiClient _trainingApiClient;
        private readonly IStateMachine _stateMachine;
        private readonly ILocalizer _localizer;

        public UserRegistrationStatusHandler(IBotRequestContextAccessor context,
            IUserTrainingApiClient trainingApiClient, IStateMachine stateMachine, ILocalizer localizer)
        {
            _context = context;
            _trainingApiClient = trainingApiClient;
            _stateMachine = stateMachine;
            _localizer = localizer;
        }
        public async Task<IResult> HandleAsync()
        {
            var userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;
            string userLevel = _context!.BotRequestContext!.Update!.Message!.Text!;
            await _trainingApiClient.SetTrainingLevel(userId, GetUserLevel(userLevel));
            await _trainingApiClient.SetRegistrationStatusAsync(userId);
            _stateMachine.SetState(MainMenuButtonsState.state);
            KeyboardButton[] buttons = new KeyboardButton[]
             {
                  new KeyboardButton(_localizer["Button.MainMenu"])
             };

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            return Results.Message(_localizer["RegistrationSuccessful"], keyboard);
        }

        private int GetUserLevel(string userLevelName)
        {
            var locale = _context!.BotRequestContext!.UserLocale;

            var allKeyForUserLevel = new Dictionary<string, EUserLevelDto>
            {
              { "Button.LevelBeginner", EUserLevelDto.Beginner},
              { "Button.LevelAmateur", EUserLevelDto.Amateur },
              { "Button.LevelPro", EUserLevelDto.Pro}
            };


            var userLevel = allKeyForUserLevel
                .ToDictionary(
                    pair => _localizer.GetLocalizedString(pair.Key, locale),
                    pair => pair.Value
                );

            return (int)userLevel[userLevelName];

        }
    }
}
