using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBoatHub.TelegramBot.DragonBot.States
{
    public class LanguageChoiceState : State
    {
        public LanguageChoiceState(int stateId) : base(stateId)
        {
        }
        public static LanguageChoiceState State
        {
            get { return new LanguageChoiceState(1); }
        }
    }
}
