using DragonBoatHub.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DragonBoatHub.API.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingSession> TrainingSessions {get; set;}
        public DbSet<UserTrainingSession> UserTrainingSessions {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrainingSession>()
                .HasKey(uts => new {uts.SessionId, uts.UserId});

            modelBuilder.Entity<UserTrainingSession>()
                .HasOne(uts => uts.TrainingSession)
                .WithMany(t => t.TrainingSessions)
                .HasForeignKey(uts => uts.SessionId);

            modelBuilder.Entity<UserTrainingSession>()
                .HasOne(uts => uts.User)
                .WithMany(u => u.TrainingSessions)
                .HasForeignKey(uts => uts.UserId);
        }
    }
}
