using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatHub.API.Domain.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }
        public int CurrentAvailableSlots { get; set; }
        public string? AgeCategory { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
