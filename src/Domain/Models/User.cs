
namespace DragonBoatHub.API.Domain.Models
{
    public class User
    {
        public enum UserStatus
        {
            Unregistered = 0,
            Registered = 1,
        }
        
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EUserLevel Level { get; set; }
        public string? Localization { get; set; }
        public long? TelegramUserId { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Unregistered;
    }

}
