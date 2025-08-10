
namespace DragonBoatHub.API.Domain.Models
{
    public class UserTrainingSession
    {   
        public long UserId {  get; set; }
        public long SessionId { get; set; }

        public User User { get; set; }

        public TrainingSession TrainingSession { get; set; }
    }
}
