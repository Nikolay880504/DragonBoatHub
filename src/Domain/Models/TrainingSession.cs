

namespace DragonBoatHub.API.Domain.Models
{
    public class TrainingSession
    {
        public long Id { get; set; }
        public DateTime TrainingDateTime { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }

        public ICollection<UserTrainingSession> TrainingSessions { get; set; } = new List<UserTrainingSession>();
    }
}
