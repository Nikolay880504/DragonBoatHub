using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfaces
{
    public interface ITrainingRepository
    {
       Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync();

       Task<bool> CheckIdAsync(long? sportsmanId);
        
    }
}
