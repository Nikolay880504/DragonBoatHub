using DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;
using Refit;

namespace DragonBoatHub.TelegramBot.DragonBot.HttpClient
{
    internal interface ITrainingApiClient
    {
        [Get("/api/trainingsessions/available")]
        Task<IEnumerable<TrainingSessionDto>> GetAvailableSessionsAsync();
    }
}
