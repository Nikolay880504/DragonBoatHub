using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    class ChooseTrainingLevelState : State
    {
        public ChooseTrainingLevelState(int stateId) : base(stateId)
        {
        }
        public static ChooseTrainingLevelState State
        {
            get { return new ChooseTrainingLevelState(8); }
        }
    }
}
