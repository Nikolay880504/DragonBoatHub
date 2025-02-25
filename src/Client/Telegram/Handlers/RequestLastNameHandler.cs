using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using DragonBot.States;
using MinimalTelegramBot;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using Results = MinimalTelegramBot.Results.Results;

namespace DragonBot.Handlers
{
    class RequestLastNameHandler : IHandler
    {
        private readonly IBotRequestContextAccessor _context;
        private readonly ITrainingApiClient _trainingApiClient;
        private readonly IStateMachine _stateMachine;
        private readonly ILocalizer _localizer;

        public RequestLastNameHandler(IBotRequestContextAccessor context,
            ITrainingApiClient trainingApiClient, IStateMachine stateMachine, ILocalizer localizer)
        {
            _context = context;
            _trainingApiClient = trainingApiClient;
            _stateMachine = stateMachine;
            _localizer = localizer;
        }
        public async Task<IResult> HandleAsync()
        {
            _stateMachine.SetState(UserBirthDayState.state);
            long userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;
            string firstName = _context!.BotRequestContext!.Update.Message.Text!;
            await _trainingApiClient.SetFirstNameAsync(userId, firstName);

            return Results.Message(_localizer["LastName"]);
        }
    }
}
