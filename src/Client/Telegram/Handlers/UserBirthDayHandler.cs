using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using DragonBot.Localization.Interfases;
using DragonBot.States;
using MinimalTelegramBot;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;
using Results = MinimalTelegramBot.Results.Results;

namespace DragonBot.Handlers
{
    class UserBirthDayHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly ITrainingApiClient _trainingApiClient;
        private readonly ILocalizer _localizer;
        private readonly IBotRequestContextAccessor _context;

        public UserBirthDayHandler(IStateMachine stateMachine,
            ITrainingApiClient trainingApiClient, ILocalizer localizer, IBotRequestContextAccessor context)
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
