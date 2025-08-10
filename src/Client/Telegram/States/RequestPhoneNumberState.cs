using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class RequestPhoneNumberState : State
    {
        public RequestPhoneNumberState(int stateId) : base(stateId)
        {
        }
        public static RequestPhoneNumberState State
        {
            get { return new RequestPhoneNumberState(3); }
        }
    }
}
