

namespace DragonBoatHub.API.Domain.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }      
    }
}
