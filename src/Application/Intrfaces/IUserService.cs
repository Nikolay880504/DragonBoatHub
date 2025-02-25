
namespace DragonBoatHub.API.Application.Intrfaces
{
    public interface IUserService
    {
        Task SetUserLocaleAsync(long userId, string locale);
        Task<string> GetUserLocleAsync(long userId);
        Task<bool> CheckRegistractionByTelegramIdAsync(long userId);
        Task SetPhoneNumberAsync(long userId, string phoneNumber);
        Task SetFirstNameAsync(long userId, string firstName);
        Task SetLastNameAsync(long userId, string lastName);
        Task SetBirthDayAsync(long userId, DateTime birthDay);
        Task SetRegistrationStatusAsync(long userId);
    }
}
