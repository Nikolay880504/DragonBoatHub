using DragonBoatHub.Contracts;


namespace DragonBoatHub.API.Application.Intrfaces
{
    public interface IAdminService
    {
        Task SaveNewTrainingSessionAsync(TrainingSessionRequestDto trainingSessionRequestDto);
    }
}
