using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    class RequestFirstNameState : State
    {
        public RequestFirstNameState(int stateId) : base(stateId)
        {
        }

        public static RequestFirstNameState state
        {
            get { return new RequestFirstNameState(4); }
        }
    }
}

