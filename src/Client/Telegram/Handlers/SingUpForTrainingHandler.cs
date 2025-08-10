using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBot.HttpClient;
using DragonBot.States;
using MinimalTelegramBot;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;
using Results = MinimalTelegramBot.Results.Results;

namespace DragonBot.Handlers
{
    internal class SingUpForTrainingHandler : TrainingMenuFactory, IHandler
    {
        private readonly IUserTrainingSessionApiClient _userTrainingSessionApiClient;
        private readonly IBotRequestContextAccessor _context;
        private readonly IStateMachine _stateMachine;
        public SingUpForTrainingHandler(IUserTrainingSessionApiClient userTrainingSessionApiClient,
            ILocalizer localizer,
            IBotRequestContextAccessor context,
            IStateMachine stateMachine) : base(localizer, stateMachine)
        {
            {
                _userTrainingSessionApiClient = userTrainingSessionApiClient;
                _context = context;
                _stateMachine = stateMachine;
            }
        }
        public async Task<IResult> HandleAsync()
        {
            _stateMachine.SetState(SaveTrainingSessionForUserState.State);
            var userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;
            var trainingSessions = await _userTrainingSessionApiClient.GetAvailableSessionsAsync(userId);
            var message = GetTrainingSessionsDescription(trainingSessions);
            ReplyKeyboardMarkup trainingListKeyboard = GetTrainingChoiceButtons(trainingSessions);
            return Results.Message(message, trainingListKeyboard);
        }      
    }
}
