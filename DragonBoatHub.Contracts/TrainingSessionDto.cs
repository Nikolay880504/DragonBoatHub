

namespace DragonBoatHub.Contracts
{
   public class TrainingSessionDto
    {
        public long Id { get; set; }
        public DateTime TrainingDateTime { get; set; }
        
        public int AvailableSlots { get; set; }

        public string TrainingAgeCategory { get; set; }
    }
}
