using MinimalTelegramBot.StateMachine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatHub.TelegramBot.DragonBot.States
{
    public class LanguageChoiceState : State
    {
        public LanguageChoiceState(int stateId) : base(stateId)
        {
        }
        public static LanguageChoiceState state
        {
            get { return new LanguageChoiceState(1); }
        }
    }
}
