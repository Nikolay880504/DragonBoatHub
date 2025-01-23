using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Application.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync();
        Task<bool> CheckRegistractionByTelegramIdAsync(long? userId);
    }
}
