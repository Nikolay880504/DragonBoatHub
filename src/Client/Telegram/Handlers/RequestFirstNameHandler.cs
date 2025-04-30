using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.StateMachine.Abstractions;
using DragonBot.States;
using MinimalTelegramBot;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using Telegram.Bot.Types.ReplyMarkups;

namespace DragonBot.Handlers
{
    class RequestFirstNameHandler : IHandler
    {
        private readonly IBotRequestContextAccessor _context;
        private readonly IUserTrainingApiClient _trainingApiClient;
        private readonly IStateMachine _stateMachine;
        private readonly ILocalizer _localizer;

        public RequestFirstNameHandler(IBotRequestContextAccessor context,
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
            string phoneNumber = _context!.BotRequestContext!.Update.Message!.Contact!.PhoneNumber;
            _stateMachine.SetState(RequestLastNameState.state);
            await _trainingApiClient.SetPhoneNumberAsync(userId, phoneNumber);
            ReplyKeyboardRemove keyboardRemove = new ReplyKeyboardRemove();

            return Results.Message(_localizer["FirstName"], keyboardRemove);
        }
    }
}
