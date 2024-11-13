using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatHub.API.Domain.Models
{
    public class TrainingRegistration
    {
        public int Id { get; set; }
        public int SportsmanId { get; set; }
        public int TrainingSessionId { get; set; }
    }
}
