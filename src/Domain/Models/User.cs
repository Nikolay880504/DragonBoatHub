using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatHub.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Level { get; set; }
        public string? Localization { get; set; }
        public int? TelegramUserId { get; set; }
    }

}
