using DragonBoatHub.TelegramBot.DragonBot.States;
using MinimalTelegramBot.StateMachine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
