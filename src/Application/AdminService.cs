using DragonBoatHub.API.Application.Intrfaces;
using DragonBoatHub.Contracts;
using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Domain.Models;


namespace DragonBoatHub.API.Application
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task SaveNewTrainingSessionAsync(TrainingSessionRequestDto trainingSessionRequestDto)
        {
            var newTraining = new TrainingSession
            {
                TrainingDateTime = trainingSessionRequestDto.TrainingDateTime,               
                Capacity = trainingSessionRequestDto.Capacity,
                Level = trainingSessionRequestDto.Level,
                MaxAge = trainingSessionRequestDto.MaxAge,
                MinAge = trainingSessionRequestDto.MinAge
            };
            await _adminRepository.SaveNewTrainingSessionAsync(newTraining);
        }
    }
}
