using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using DragonBot.HttpClient.ModelsDto;
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
    class UserRegistrationStatusHandler : IHandler
    {
        private readonly IBotRequestContextAccessor _context;
        private readonly ITrainingApiClient _trainingApiClient;
        private readonly IStateMachine _stateMachine;
        private readonly ILocalizer _localizer;

        public UserRegistrationStatusHandler(IBotRequestContextAccessor context,
            ITrainingApiClient trainingApiClient, IStateMachine stateMachine, ILocalizer localizer)
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
            var userDTO = new UserDTO { BirthDay = birthDay, TelegramUserId = userId };
            await _trainingApiClient.SetBirthDayAsync(userDTO);
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

        bool IsValidDateOfBirth(string input)
        {
            var datePattern = @"^\d{2}\.\d{2}\.\d{4}$";
            var regex = new Regex(datePattern);
            return regex.IsMatch(input);
        }
    }
}
