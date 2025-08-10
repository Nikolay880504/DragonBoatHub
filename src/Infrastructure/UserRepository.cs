using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Infrastructure.Context;
using DragonBoatHub.API.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DragonBoatHub.API.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task SetBirthDayAsync(User user)
        {

            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetFirstNameAsync(User user)
        {

            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetLastNameAsync(User user)
        {
            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

        }

        public async Task SetPhoneNumberAsync(User user)
        {
            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetRegistrationStatusAsync(User user)
        {
            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task SetUserLocaleAsync(User user)
        {
            if (user is not null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetTrainingLevelAsync(User user)
        {

            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetUserByTelegramIdAsync(long userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.TelegramUserId == userId);
        }

        public async Task UpdateUserLocaleAsync(User user)
        {
            if (user is not null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}