using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task SetUserLocaleAsync(User user);
        Task UpdateUserLocaleAsync(User user);
        Task SetPhoneNumberAsync(User user);
        Task SetFirstNameAsync(User user);
        Task SetLastNameAsync(User user);
        Task SetBirthDayAsync (User user);
        Task SetRegistrationStatusAsync(User user);
        Task SetTrainingLevelAsync(User user);
        Task<User?> GetUserByTelegramIdAsync(long telegramUserId);
    }
}
