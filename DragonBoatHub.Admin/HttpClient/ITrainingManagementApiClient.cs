using DragonBoatHub.Contracts;
using Refit;

namespace DragonBoatHub.Admin.HttpClient
{
    public interface ITrainingManagementApiClient
    {
        [Post("/api/AdminTrainingSession/save-newTrainingSession")]
        Task SaveNewTrainingSessionAsync([Body] TrainingSessionRequestDto createTraining);
    }

}
