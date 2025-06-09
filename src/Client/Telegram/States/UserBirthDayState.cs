using MinimalTelegramBot.StateMachine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBot.States
{
    class UserBirthDayState : State
    {
        public UserBirthDayState(int stateId) : base(stateId)
        {
        }

        public static UserBirthDayState state
        {
            get { return new UserBirthDayState(6);}
        }
    }
}
