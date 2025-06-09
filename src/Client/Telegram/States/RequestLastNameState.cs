using MinimalTelegramBot.StateMachine.Abstractions;


namespace DragonBot.States
{
    class RequestLastNameState : State
    {
        public RequestLastNameState(int stateId) : base(stateId)
        {
        }

        public static RequestLastNameState state
        {
            get { return new RequestLastNameState(5); }
        }
    }
}
