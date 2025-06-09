using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckRegistrationAsync(long userId);
        Task SetUserLocaleAsync(long userId, string locale);
        Task<string> GetUserLocaleOrDefaultAsync(long userId);
        Task SetPhoneNumberAsync(long userId, string phoneNumber);
        Task  SetFirstNameAsync(long userId, string firstName);
        Task SetLastNameAsync(long userId, string lastName);
        Task SetBirthDayAsync (long userId, DateTime birthDay);
        Task SetRegistrationStatusAsync(long userId);

        Task SetTrainingLevel(long userId,  int userLevel);

    }
}
