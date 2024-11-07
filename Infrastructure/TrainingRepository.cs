using DragonBoatDomain.Interfases;
using DragonBoatDomain.Models;

namespace Infrastructure
{
    public class TrainingRepository : ITrainingRepository
    {
        public Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
