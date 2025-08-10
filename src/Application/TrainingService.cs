using DragonBoatHub.API.Domain.Models;
using DragonBoatHub.Contracts;
using DragonBoatHub.API.Application.Interfaces;
using DragonBoatHub.API.Domain.Interfaces;
namespace DragonBoatHub.API.Application
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IUserRepository _userRepository;
        public TrainingService(ITrainingRepository trainingRepository, IUserRepository userRepository)
        {
            _trainingRepository = trainingRepository;
            _userRepository = userRepository;
        }

        public async Task<List<TrainingSessionDto>> GetAvailableSessionsAsync(long telegramUserId)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramUserId);
            if (existingUser is null)
                throw new InvalidOperationException($"User with Telegram ID {telegramUserId} not found.");

            var userAge = GetUserAge(existingUser);

            List<TrainingSession> sessions = await _trainingRepository.GetAvailableSessionsAsync(userAge, (int)existingUser!.Level, existingUser.Id);

            List<TrainingSessionDto> trainingSession = new List<TrainingSessionDto>(sessions.Count);


            for (int i = 0; i < sessions.Count; i++)
            {
                var trainingAgeCategory = GetTrainingAgeCategory(sessions[i].MaxAge, sessions[i].MinAge);
                trainingSession.Add(new TrainingSessionDto()
                {
                    TrainingDateTime = sessions[i].TrainingDateTime,
                    AvailableSlots = sessions[i].Capacity,
                    TrainingAgeCategory = trainingAgeCategory,
                    Id = sessions[i].Id
                });
            }

            return trainingSession;
        }

        public async Task SetTrainingSessionForUserAsync(long telegramUserId, long trainingSessionId)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramUserId);
            var existingTrainingSession = await _trainingRepository.GetTrainingSessionByIdOrNullAsync(trainingSessionId);

            if (existingUser is null)
                throw new InvalidOperationException($"User with Telegram ID {telegramUserId} not found.");

            if (existingTrainingSession is null)
                throw new InvalidOperationException($"Training session with ID {trainingSessionId} not found.");

            var userTrainingSession = new UserTrainingSession
            {
                SessionId = trainingSessionId,
                UserId = existingUser.Id
            };
           
            await _trainingRepository.SetTrainingSessionForUserAsync(userTrainingSession);
          
            await _trainingRepository.UpdateTrainingSessionCapacityAsync(existingTrainingSession);
        }

        string GetTrainingAgeCategory(int MaxAge, int MinAge)
        {
            var ageCategories = new Dictionary<string, (int Min, int Max)>
            {
                ["<15"] = (Min: 0, Max: 15),
                ["16-18"] = (Min: 16, Max: 18),
                ["19-39"] = (Min: 19, Max: 39),
                ["40-49"] = (Min: 40, Max: 49),
                ["50-59"] = (Min: 50, Max: 59),
                ["40+"] = (Min: 40, Max: 100),
                ["60+"] = (Min: 60, Max: 100),
                ["Open"] = (Min: 0, Max: 100)
            };

            return ageCategories.Where(a => a.Value.Min == MinAge && a.Value.Max == MaxAge).FirstOrDefault().Key;
        }

        int GetUserAge(User user)
        {
            if (user == null)
                throw new Exception($"User with id {user.TelegramUserId} not found");

            var today = DateTime.Today;

            int userAge = today.Year - user.DateOfBirth.Year;

            if (user.DateOfBirth.Date > today.AddYears(-userAge))
                userAge--;

            return userAge;
        }
    }
}
