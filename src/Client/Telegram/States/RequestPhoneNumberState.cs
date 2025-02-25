
using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class RequestPhoneNumberState : State
    {
        public RequestPhoneNumberState(int stateId) : base(stateId)
        {
        }
        public static RequestPhoneNumberState state
        {
            get { return new RequestPhoneNumberState(3); }
        }
    }
}
