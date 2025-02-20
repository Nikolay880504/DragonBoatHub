using DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;
using Refit;

namespace DragonBoatHub.TelegramBot.DragonBot.HttpClient
{
    internal interface ITrainingApiClient
    {
        [Get("/api/trainingsessions/available")]

        Task<List<TrainingSessionDto>> GetAvailableSessionsAsync();

        [Get("/api/user/status/{userId}")]
        Task<bool> CheckRegistractionByTelegramIdAsync(long? userId);

        [Post("/api/user/set-locale/{telegramUserId}/{locale}")]
        Task SetUserLocalizationAsync(long telegramUserId, string locale);

        [Get("/api/user/get-locale/{telegramUserId}")]
        Task<string> GetUserLocalizationAsync(long telegramUserId);
    }
}
