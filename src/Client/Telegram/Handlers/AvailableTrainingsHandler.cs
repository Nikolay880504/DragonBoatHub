using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Results = MinimalTelegramBot.Results.Results;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using Telegram.Bot.Types.ReplyMarkups;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.Localization.Abstractions;


namespace DragonBot.Handlers
{
    internal class AvailableTrainingsHandler : IHandler
    {
        private readonly IUserTrainingApiClient _trainingApiClient;
        private readonly ILocalizer _localizer;

        public AvailableTrainingsHandler(IUserTrainingApiClient trainingApiClient, ILocalizer localizer)
        {
            _trainingApiClient = trainingApiClient;
            _localizer = localizer;
        }
        public async Task<IResult> HandleAsync()
        {
            var message = _localizer["AvailableTrainings"];
            ReplyKeyboardMarkup trainingListKeyboard = await GetTrainingListKeyboard();

            return Results.Message(message, trainingListKeyboard);
        }

        private async Task<ReplyKeyboardMarkup> GetTrainingListKeyboard()
        {
            List<TrainingSessionDto> trainingSessions = await _trainingApiClient.GetAvailableSessionsAsync();

            var buttons = trainingSessions.
                         Select( session => new [] { new KeyboardButton(session.StartDate.ToString("yyyy-MM-dd"))}).
                         ToArray();
            return new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true
            };
        }
    }
}
