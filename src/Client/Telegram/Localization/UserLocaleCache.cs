using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using DragonBot.Localization.Interfases;
using MinimalTelegramBot.Localization.Abstractions;
using System.Collections.Concurrent;

namespace DragonBot.Localization
{
    class UserLocaleCache : IUserLocaleCache
    {
        private readonly IUserTrainingApiClient _trainingApiClient;
        public UserLocaleCache(IUserTrainingApiClient trainingApiClient)
        {
            _trainingApiClient = trainingApiClient;
        }
        private readonly ConcurrentDictionary<long, Locale> _userLocales = new();

        public async Task<Locale> GetUserLocaleAsync(long userId)
        {
            if (!_userLocales.TryGetValue(userId, out var locale))
            {
                var userLocale = await _trainingApiClient.GetUserLocalizationAsync(userId);
                _userLocales.TryAdd(userId, new Locale(userLocale));
            }

            return _userLocales[userId];
        }

        public void UpdateLocalCache(long userId, string locale)
        {
            _userLocales[userId] = new Locale(locale);

        }
    }
}
