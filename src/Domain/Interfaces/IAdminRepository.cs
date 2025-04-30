
using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfaces
{
     public interface IAdminRepository
    {
      public  Task SaveNewTrainingSessionAsync(TrainingSession newTraining);
    }
}
