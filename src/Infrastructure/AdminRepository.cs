using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Domain.Models;
using DragonBoatHub.API.Infrastructure.Context;

namespace DragonBoatHub.API.Infrastructure
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveNewTrainingSessionAsync(TrainingSession newTraining)
        {
            _context.TrainingSessions.Add(newTraining);
            await _context.SaveChangesAsync();
        }
    }
}
