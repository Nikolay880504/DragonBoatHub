using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class SingUpForTrainingState : State
    {
        public SingUpForTrainingState(int stateId) : base(stateId)
        {

        }
        public static SingUpForTrainingState State
        {
            get { return new SingUpForTrainingState(10); }
        }
    }
}
