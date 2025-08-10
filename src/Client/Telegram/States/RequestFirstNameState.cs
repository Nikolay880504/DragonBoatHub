using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    class RequestFirstNameState : State
    {
        public RequestFirstNameState(int stateId) : base(stateId)
        {
        }

        public static RequestFirstNameState State
        {
            get { return new RequestFirstNameState(4); }
        }
    }
}

