using DragonBoatHub.Contracts;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;
using Refit;


namespace DragonBoatHub.TelegramBot.DragonBot.HttpClient
{
    internal interface IUserTrainingApiClient
    {
        [Get("/api/trainingsessions/available")]

        Task<List<TrainingSessionDto>> GetAvailableSessionsAsync();

        [Get("/api/user/status/{userId}")]
        Task<bool> CheckRegistractionByTelegramIdAsync(long? userId);

        [Post("/api/user/set-locale/{telegramUserId}/{locale}")]
        Task SetUserLocalizationAsync(long telegramUserId, string locale);

        [Get("/api/user/get-locale/{telegramUserId}")]
        Task<string> GetUserLocalizationAsync(long telegramUserId);

        [Post("/api/user/set-phoneNumber/{telegramUserId}/{phoneNumber}")]
        Task SetPhoneNumberAsync(long telegramUserId, string phoneNumber);

        [Post("/api/user/set-firstName/{telegramUserId}/{firstName}")]
        Task SetFirstNameAsync(long telegramUserId, string firstName);
        [Post("/api/user/set-lastName/{telegramUserId}/{firstName}")]
        Task SetLastNameAsync(long telegramUserId, string firstName);

        [Post("/api/user/set-dayOfBirth")]
        Task SetBirthDayAsync([Body] UserBirthdayDto user);
        [Post("/api/user/set-registrationStatus/{telegramUserId}")]
        Task SetRegistrationStatusAsync(long telegramUserId);

        [Post("/api/user/set-trainingLevel/{telegramUserId}/{userLevel}")]
        Task SetTrainingLevel(long telegramUserId, int userLevel);
    }
}
