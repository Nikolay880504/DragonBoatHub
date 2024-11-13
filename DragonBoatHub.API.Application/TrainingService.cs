using DragonBoatHub.API.Domain.Models;
using DragonBoatHub.API.Domain.Interfases;

namespace DragonBoatHub.API.Application
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync()
        {
            var sessions = await _trainingRepository.GetAvailableSessionsAsync();
            return sessions.ToList();
        }
    }
}
