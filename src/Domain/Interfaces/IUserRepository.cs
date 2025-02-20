

namespace DragonBoatHub.API.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckIdAsync(long? userId);

        Task SetUserLocaleAsync(long telegramUserId, string locale);
        Task<string?> GetUserLocaleOrNullAsync(long? telegramUserId);
    }
}
