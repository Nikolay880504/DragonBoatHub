using DragonBoatHub.API.Application.Intrfaces;
using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Domain.Models;

namespace DragonBoatHub.API.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SetUserLocaleAsync(long telegramId, string locale)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
            {
                var newUser = new User { TelegramUserId = telegramId, Localization = locale };
                await _userRepository.SetUserLocaleAsync(newUser);
            }
            else
            {
                existingUser.Localization = locale;
                await _userRepository.UpdateUserLocaleAsync(existingUser);
            }
        }
        public async Task<bool> CheckRegistractionByTelegramIdAsync(long telegramId)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
            {
                return false;
            }
            return true;
        }

        public async Task<string> GetUserLocaleOrDefaultAsync(long telegramId)
        {
            var defaultLocalization = "sl";
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (!string.IsNullOrEmpty(existingUser?.Localization))
            {
                return existingUser.Localization;
            }
            return defaultLocalization;
        }

        public async Task SetPhoneNumberAsync(long telegramId, string phoneNumber)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
                throw new InvalidOperationException($" User with telegram ID :{telegramId} not found!");

            existingUser.PhoneNumber = phoneNumber;
            await _userRepository.SetPhoneNumberAsync(existingUser);   
        }

        public async Task SetFirstNameAsync(long telegramId, string firstName)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
                throw new InvalidOperationException($" User with telegram ID :{telegramId} not found!");

            existingUser.FirstName = firstName;
            await _userRepository.SetFirstNameAsync(existingUser);  
        }

        public async Task SetLastNameAsync(long telegramId, string lastName)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
                throw new InvalidOperationException($" User with telegram ID :{telegramId} not found!");

            existingUser.LastName = lastName;
            await _userRepository.SetLastNameAsync(existingUser);
        }


        public async Task SetBirthDayAsync(long telegramId, DateTime birthDay)
        {

            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
                throw new InvalidOperationException($" User with telegram ID :{telegramId} not found!");

            existingUser.DateOfBirth = birthDay;
            await _userRepository.SetLastNameAsync(existingUser);
        }

        public async Task SetRegistrationStatusAsync(long telegramId)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);

            if (existingUser is null)
                throw new InvalidOperationException($" User with telegram ID :{telegramId} not found!");

            existingUser.Status = User.UserStatus.Registered;
            await _userRepository.SetLastNameAsync(existingUser);
        }

        public async Task SetTrainingLevel(long telegramId, int userLevel)
        {
            var existingUser = await _userRepository.GetUserByTelegramIdAsync(telegramId);
            if (existingUser is null)
                throw new InvalidOperationException($" User with telegram ID :{telegramId} not found!");

            existingUser.Level = (EUserLevel)userLevel;
            await _userRepository.SetTrainingLevelAsync(existingUser);
        }
    }
}
