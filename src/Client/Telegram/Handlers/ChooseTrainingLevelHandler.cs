using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using DragonBoatHub.Contracts;
using DragonBot.States;
using MinimalTelegramBot;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using System.Globalization;
using System.Text.RegularExpressions;
using Telegram.Bot.Types.ReplyMarkups;
using Results = MinimalTelegramBot.Results.Results;

namespace DragonBot.Handlers
{
    class ChooseTrainingLevelHandler : IHandler
    {
        private readonly IBotRequestContextAccessor _context;
        private readonly IUserTrainingApiClient _trainingApiClient;
        private readonly IStateMachine _stateMachine;
        private readonly ILocalizer _localizer;


        public ChooseTrainingLevelHandler(IBotRequestContextAccessor context,
            IUserTrainingApiClient trainingApiClient, IStateMachine stateMachine, ILocalizer localizer)
        {
            _context = context;
            _trainingApiClient = trainingApiClient;
            _stateMachine = stateMachine;
            _localizer = localizer;
        }
        public async Task<IResult> HandleAsync()
        {
            long userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;
            string birthDate = _context!.BotRequestContext!.Update!.Message!.Text!;
            if (!IsValidDateOfBirth(birthDate))
            {
                return Results.Message(_localizer["BirthDayCorrect"]);
            }
            var birthDay = DateTime.ParseExact(birthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var userDTO = new UserBirthdayDto { BirthDay = birthDay, TelegramUserId = userId };
            _stateMachine.SetState(UserRegistrationStatusState.state);
            await _trainingApiClient.SetBirthDayAsync(userDTO);
            
            KeyboardButton[] buttons = new KeyboardButton[]
            {
                  new KeyboardButton(_localizer["Button.LevelBeginner"]),
                  new KeyboardButton(_localizer["Button.LevelAmateur"]),
                  new KeyboardButton(_localizer["Button.LevelPro"])
            };

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            return Results.Message(_localizer["ChooseTrainingLevel"], keyboard);
        }

        bool IsValidDateOfBirth(string input)
        {
            var datePattern = @"^\d{2}\.\d{2}\.\d{4}$";
            var regex = new Regex(datePattern);
            return regex.IsMatch(input);
        }
    }
}
