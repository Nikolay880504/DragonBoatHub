using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfases
{
    public interface ITrainingRepository
    {
       Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync();
    }
}
