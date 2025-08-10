using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfaces
{
    public interface ITrainingRepository
    {
        Task<List<TrainingSession>> GetAvailableSessionsAsync(int userAge, int userLevel, long userId);
        Task SetTrainingSessionForUserAsync(UserTrainingSession userTrainingSession);
        Task<TrainingSession?> GetTrainingSessionByIdOrNullAsync(long trainingSessionId);
        Task UpdateTrainingSessionCapacityAsync(TrainingSession trainingSession);
    }
}
