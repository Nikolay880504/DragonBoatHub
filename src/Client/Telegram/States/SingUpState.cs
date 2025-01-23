using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class SingUpState : State
    {
        public SingUpState(int stateId) : base(stateId)
        {
        }
        public static SingUpState state
        {
            get { return new SingUpState(3); }
        }
    }
}
