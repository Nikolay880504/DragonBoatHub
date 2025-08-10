using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class RequestLastNameState : State
    {
        public RequestLastNameState(int stateId) : base(stateId)
        {
        }

        public static RequestLastNameState State
        {
            get { return new RequestLastNameState(5); }
        }
    }
}
