using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    class UserBirthDayState : State
    {
        public UserBirthDayState(int stateId) : base(stateId)
        {
        }

        public static UserBirthDayState State
        {
            get { return new UserBirthDayState(6);}
        }
    }
}
