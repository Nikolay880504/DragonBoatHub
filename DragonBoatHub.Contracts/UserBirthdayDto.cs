using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatHub.Contracts
{
    public class UserBirthdayDto
    {
        public long TelegramUserId { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
