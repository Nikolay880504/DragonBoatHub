using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    class UserRegistrationStatusState : State
    {
        public UserRegistrationStatusState(int stateId) : base(stateId)
        {
        }

        public static UserRegistrationStatusState State
        {
            get { return new UserRegistrationStatusState(7); }
        }
    }
}
