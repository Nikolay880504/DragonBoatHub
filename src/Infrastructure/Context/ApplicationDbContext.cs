using DragonBoatHub.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DragonBoatHub.API.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<TrainingSession> TrainingSessions {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
