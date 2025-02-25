
using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class MainMenuButtonsState : State
    {
        public MainMenuButtonsState(int stateId) : base(stateId)
        {
        }
        public static MainMenuButtonsState state
        {
            get { return new MainMenuButtonsState(2); }
        }
    }
}
