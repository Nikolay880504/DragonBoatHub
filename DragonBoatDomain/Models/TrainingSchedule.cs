using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatDomain.Models
{
    public class TrainingSchedule
    {
        public int Id { get; set; }

        public List<TrainingSession> Monday { get; set; } = new List<TrainingSession>();
        public List<TrainingSession> Tuesday { get; set; } = new List<TrainingSession>();
        public List<TrainingSession> Wednesday { get; set; } = new List<TrainingSession>();
        public List<TrainingSession> Thursday { get; set; } = new List<TrainingSession>();
        public List<TrainingSession> Friday { get; set; } = new List<TrainingSession>();

    }
}