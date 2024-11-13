using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfases
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync();
    }
}
