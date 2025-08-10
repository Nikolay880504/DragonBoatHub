using DragonBoatHub.API.Domain.Models;
using DragonBoatHub.Contracts;
namespace DragonBoatHub.API.Application.Interfaces
{
    public interface ITrainingService
    {
        Task<List<TrainingSessionDto>> GetAvailableSessionsAsync(long telegramUserId);
        Task SetTrainingSessionForUserAsync(long telegramUserId, long trainingSessionId);
    }
}
