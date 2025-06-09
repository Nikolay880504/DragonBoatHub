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
    class UserBirthDayHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUserTrainingApiClient _trainingApiClient;
        private readonly ILocalizer _localizer;
        private readonly IBotRequestContextAccessor _context;

        public UserBirthDayHandler(IStateMachine stateMachine,
            IUserTrainingApiClient trainingApiClient, ILocalizer localizer, IBotRequestContextAccessor context)
        {
            _stateMachine = stateMachine;
            _trainingApiClient = trainingApiClient;
            _localizer = localizer;
            _context = context;
        }

        public async Task<IResult> HandleAsync()
        {
            long userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;
            string lastName = _context!.BotRequestContext!.Update.Message.Text!;
            await _trainingApiClient.SetLastNameAsync(userId, lastName);
            _stateMachine.SetState(ChooseTrainingLevelState.state);
            return Results.Message(_localizer["BirthDay"]);
        }
    }
}
