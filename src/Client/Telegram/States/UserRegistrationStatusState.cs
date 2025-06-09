using MinimalTelegramBot.StateMachine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBot.States
{
    class UserRegistrationStatusState : State
    {
        public UserRegistrationStatusState(int stateId) : base(stateId)
        {
        }

        public static UserRegistrationStatusState state
        {

            get { return new UserRegistrationStatusState(7); }
        }
    }
}
