using DragonBoatHub.API.Domain.Interfases;
using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Infrastructure.Data
{
    public class TrainingRepository : ITrainingRepository
    {
       
        public Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync()
        {
            var sessions = new List<TrainingSession>
    {
        new TrainingSession
        {
            AgeCategory = "Old",
            CurrentAvailableSlots = 20,
            StartDate = new DateTime(2024, 11, 10, 9, 0, 0),
            EndDate = new DateTime(2024, 11, 10, 10, 0, 0)
        },
        new TrainingSession
        {
            AgeCategory = "Young",
            CurrentAvailableSlots = 15,
            StartDate = new DateTime(2024, 11, 11, 11, 0, 0),
            EndDate = new DateTime(2024, 11, 11, 12, 0, 0)
        },
        new TrainingSession
        {
            AgeCategory = "Adults",
            CurrentAvailableSlots = 10,
            StartDate = new DateTime(2024, 11, 12, 14, 0, 0),
            EndDate = new DateTime(2024, 11, 12, 15, 0, 0)
        }
    };
            return Task.FromResult<IEnumerable<TrainingSession>>(sessions);
        }
    }
}
