using DragonBoatHub.API.Application.Intrfaces;
using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Domain.Models;
using DragonBoatHub.Contracts;

namespace DragonBoatHub.API.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SetUserLocaleAsync(long userId, string locale)
        {
            await _userRepository.SetUserLocaleAsync(userId, locale);
        }
        public async Task<bool> CheckRegistractionByTelegramIdAsync(long userId)
        {
            return await _userRepository.CheckRegistrationAsync(userId);
        }

        public async Task<string> GetUserLocleAsync(long userId)
        {
            return await _userRepository.GetUserLocaleOrDefaultAsync(userId);
        }

        public async Task SetPhoneNumberAsync(long userId, string phoneNumber)
        {
            await _userRepository.SetPhoneNumberAsync(userId, phoneNumber);
        }
        public async Task SetFirstNameAsync(long userId, string firstName)
        {
            await _userRepository.SetFirstNameAsync(userId, firstName);
        }
       
        public async Task SetLastNameAsync(long userId, string lastName)
        {
            await _userRepository.SetLastNameAsync(userId, lastName);
        }

        public async Task SetBirthDayAsync(long userId, DateTime birthDay)
        {
            
            await _userRepository.SetBirthDayAsync(userId, birthDay);
        }

        public async Task SetRegistrationStatusAsync(long trlegramId)
        {
            await _userRepository.SetRegistrationStatusAsync(trlegramId);
        }

        public async Task SetTrainingLevel(long userId, int userLevel)
        {
            await _userRepository.SetTrainingLevel(userId, userLevel);
        }
    }
}
