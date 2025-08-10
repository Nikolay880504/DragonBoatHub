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
    internal class SaveTrainingSessionForUser : TrainingMenuFactory, IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly IBotRequestContextAccessor _context;
        private readonly IUserTrainingSessionApiClient _userTrainingSessionApiClient;

        public SaveTrainingSessionForUser(IStateMachine stateMachine,
            IBotRequestContextAccessor context, ILocalizer localizer,
            IUserTrainingSessionApiClient userTrainingSessionApiClient) : base(localizer, stateMachine) {
            {
                _stateMachine = stateMachine;
                _context = context;
                _userTrainingSessionApiClient = userTrainingSessionApiClient;
            }
        }

        public async Task<IResult> HandleAsync()
        {          
            var userId = _context!.BotRequestContext!.Update!.Message!.From!.Id;
            var textButton = _context!.BotRequestContext!.Update.Message.Text!;
            var currentState = _stateMachine.GetState() as SaveTrainingSessionForUserState;
            if (currentState is not null)
            {
                var trainingSessionsId =  currentState.GetTrainingSessionsId();

                if (trainingSessionsId.TryGetValue(textButton, out var sessionId))
                {
                   await _userTrainingSessionApiClient.SetTrainingSessionForUserAsync(userId, long.Parse(sessionId));
                   
                }              
            }
            var trainingSessions = await _userTrainingSessionApiClient.GetAvailableSessionsAsync(userId);
            var message = GetTrainingSessionsDescription(trainingSessions);
            ReplyKeyboardMarkup trainingListKeyboard = GetTrainingChoiceButtons(trainingSessions);
            return Results.Message(message, trainingListKeyboard);
        }

    }
}
