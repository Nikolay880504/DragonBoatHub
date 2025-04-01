using DragonBoatHub.TelegramBot.DragonBot.States;
using MinimalTelegramBot.StateMachine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBot.States
{
    class ChooseTrainingLevelState : State
    {
        public ChooseTrainingLevelState(int stateId) : base(stateId)
        {
        }
        public static ChooseTrainingLevelState state
        {
            get { return new ChooseTrainingLevelState(8); }
        }
    }
}
