using DragonBoatHub.Contracts;
using DragonBot.States;
using MinimalTelegramBot.Localization.Abstractions;
using MinimalTelegramBot.StateMachine.Abstractions;
using System.Globalization;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace DragonBot.Handlers
{
    internal abstract class TrainingMenuFactory
    {
        private readonly ILocalizer _localizer;
        private readonly IStateMachine _stateMachine;

        public TrainingMenuFactory(ILocalizer localizer, IStateMachine stateMachine)
        {
            _localizer = localizer;
            _stateMachine = stateMachine;
        }
        protected ReplyKeyboardMarkup GetTrainingChoiceButtons(List<TrainingSessionDto> trainingSessions)
        {
            var menuButton = new[] { new KeyboardButton(_localizer["Button.MainMenu"]) };
            var sessionsId = trainingSessions.Select((s, index) => new KeyValuePair<string, string>(
                (index + 1).ToString(),
                s.Id.ToString()
                )).ToDictionary(x => x.Key, x => x.Value);

            var currentState = _stateMachine.GetState() as SaveTrainingSessionForUserState;

            if (currentState is not null)
            {
                currentState.SetTrainingSessionsId(sessionsId);
            }

            var buttons = sessionsId.
                         Select(session => new[] { new KeyboardButton(session.Key) }).ToList();
            buttons.Add(menuButton);

            return new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true
            };
        }

        protected string GetTrainingSessionsDescription(List<TrainingSessionDto> trainingSessions)
        {
            var culture = new CultureInfo(_localizer["CultureInfo"]);
            var counter = 1;
            var description = new StringBuilder();
            description.AppendLine(_localizer["AvailableTrainings"]);

            foreach (var session in trainingSessions)
            {
                description.Append(counter++)
                    .Append(") ")
                    .Append(session.TrainingDateTime.ToString("dd.MM HH:mm", culture))
                    .Append(' ')
                    .Append(_localizer["Age"])
                    .Append(' ')
                    .Append(session.TrainingAgeCategory)
                    .Append(' ')
                    .Append(session.AvailableSlots)
                    .Append(' ')
                    .Append(_localizer["Slots"])
                    .AppendLine();
            }

            return description.ToString();
        }
    }
}
