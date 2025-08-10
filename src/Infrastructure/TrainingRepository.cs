
using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Domain.Models;
using DragonBoatHub.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace DragonBoatHub.API.Infrastructure
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TrainingSession>> GetAvailableSessionsAsync(int userAge, int userLevel, long userId)
        {
            return await _context.TrainingSessions
               .Where(s => userAge >= s.MinAge && userAge <= s.MaxAge &&
                     (s.Level == userLevel || s.Level == 0) &&
                     !s.TrainingSessions.Any(uts => uts.UserId == userId))
                     .ToListAsync();
        }

        public async Task<TrainingSession?> GetTrainingSessionByIdOrNullAsync(long trainingSessionId)
        {
            return await _context.TrainingSessions.FirstOrDefaultAsync(t => t.Id == trainingSessionId);
        }

        public async Task SetTrainingSessionForUserAsync(UserTrainingSession userTrainingSession)
        {
            _context.UserTrainingSessions.Add(userTrainingSession);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrainingSessionCapacityAsync(TrainingSession trainingSession)
        {
            _context.TrainingSessions.Where(ts => ts.Id == trainingSession.Id && ts.Capacity > 0)
                .ExecuteUpdate(ts => ts.SetProperty(ts => ts.Capacity, ts => ts.Capacity - 1));
            await _context.SaveChangesAsync();
        }
    }
}
