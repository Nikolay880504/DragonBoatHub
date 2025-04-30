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
        public async Task<bool> CheckRegistrationAsync(long userId)
        {
            var existingUser = await _context.Users
                .Where(u => u.TelegramUserId == userId)
                .Select(u => u.Status)
                .FirstOrDefaultAsync();

            return existingUser == User.UserStatus.Registered;
        }

        public async Task<string> GetUserLocaleOrDefaultAsync(long userId)
        {
            var defaultLocalization = "sn";
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.TelegramUserId == userId);

            if (!string.IsNullOrEmpty(existingUser?.Localization))
            {
                return existingUser.Localization;
            }

            return defaultLocalization;
        }

        public async Task SetBirthDayAsync(long userId, DateTime birthDay)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is not null)
            {
                existingUser.DateOfBirth = birthDay;
                _context.Users.Update(existingUser);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SetFirstNameAsync(long userId, string firstName)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is not null)
            {
                existingUser.FirstName = firstName;
                _context.Users.Update(existingUser);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SetLastNameAsync(long userId, string lastName)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is not null)
            {
                existingUser.LastName = lastName;
                _context.Users.Update(existingUser);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SetPhoneNumberAsync(long userId, string phoneNumber)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is not null)
            {
                existingUser.PhoneNumber = phoneNumber;
                _context.Users.Update(existingUser);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SetRegistrationStatusAsync(long userId)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is not null)
            {
                existingUser.Status = User.UserStatus.Registered;
                _context.Users.Update(existingUser);
            }
            await _context.SaveChangesAsync();
        }

        public async Task SetUserLocaleAsync(long userId, string locale)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is null)
            {
                var newUser = new User { TelegramUserId = userId, Localization = locale };
                _context.Users.Add(newUser);
            }
            else
            {
                existingUser.Localization = locale;
                _context.Users.Update(existingUser);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SetTrainingLevel(long userId, int userLevel)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.TelegramUserId == userId);

            if (existingUser is not null)
            {
                existingUser.Level = (EUserLevel)userLevel;
                _context.Users.Update(existingUser);
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
