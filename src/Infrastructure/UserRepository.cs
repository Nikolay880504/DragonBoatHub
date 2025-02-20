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
        public Task<bool> CheckIdAsync(long? sportsmanId)
        {
            return Task.FromResult(true);
        }

        public async Task<string?> GetUserLocaleOrNullAsync(long? telegramUserId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.TelegramUserId == telegramUserId);

            return user?.Localization; 
        }


        public async Task SetUserLocaleAsync(long telegramUserId, string locale)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.TelegramUserId == telegramUserId);

            if (existingUser == null)
            {
                var newUser = new User { TelegramUserId = telegramUserId, Localization = locale };
                _context.Users.Add(newUser);
            }
            else
            {
                existingUser.Localization = locale;
            }
            await _context.SaveChangesAsync();
        }
    }
}
