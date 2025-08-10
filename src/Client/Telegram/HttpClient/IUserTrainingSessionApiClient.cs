using Refit;
using DragonBoatHub.Contracts;

namespace DragonBot.HttpClient
{
    internal interface IUserTrainingSessionApiClient
    {
        [Get("/api/usertrainingsession/available/{telegramUserId}")]
        Task<List<TrainingSessionDto>> GetAvailableSessionsAsync(long telegramUserId);

        [Post("/api/usertrainingsession/set-trainingForUser/{telegramUserId}/{trainingSessionId}")]
        Task SetTrainingSessionForUserAsync(long telegramUserId, long trainingSessionId);

    }
}
