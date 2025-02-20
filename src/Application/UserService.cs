using DragonBoatHub.API.Application.Intrfaces;
using DragonBoatHub.API.Domain.Interfaces;


namespace DragonBoatHub.API.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SetUserLocaleAsync(long telegramUserId, string locale)
        {
           await _userRepository.SetUserLocaleAsync(telegramUserId, locale);
        }
        public async Task<bool> CheckRegistractionByTelegramIdAsync(long? sportsmanId)
        {
            var IsAuthenticated = await _userRepository.CheckIdAsync(sportsmanId);

            return IsAuthenticated;
        }

        public async Task<string?> GetUserLocleAsync(long telegramUserId)
        {
           return await _userRepository.GetUserLocaleOrNullAsync(telegramUserId);
        }
    }
}
