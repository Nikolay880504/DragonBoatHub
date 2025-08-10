
using DragonBot.Localization.Interfases;
using MinimalTelegramBot.Localization.Abstractions;

namespace DragonBot.Localization
{
    internal class UserLocaleProvider : IUserLocaleProvider

    {
        private readonly IUserLocaleCache _userLocaleCache;

        public UserLocaleProvider(IUserLocaleCache userLocaleCache)
        {
            _userLocaleCache = userLocaleCache;
        }

        public async Task<Locale> GetUserLocaleAsync(long userId, CancellationToken cancellationToken = default)
        {
            return await _userLocaleCache.GetUserLocaleAsync(userId);
        }
    }
}
