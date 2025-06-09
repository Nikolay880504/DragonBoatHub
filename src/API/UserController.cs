using Microsoft.AspNetCore.Mvc;
using DragonBoatHub.API.Application.Intrfaces;
using DragonBoatHub.API.Models;


namespace DragonBoatHub.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("status/{userId}")]
        public async Task<IActionResult> CheckRegistractionByTelegramIdAsync(long userId)
        {
            var IsAuthenticated = await _userService.CheckRegistractionByTelegramIdAsync(userId);
            return Ok(IsAuthenticated);
        }

        [HttpPost("set-locale/{userId}/{locale}")]
        public async void SetUserLocaleAsync(long userId, string locale)
        {
            await _userService.SetUserLocaleAsync(userId, locale);
        }

        [HttpGet("get-locale/{userId}")]
        public async Task<string?> GetUserLocaleAsync(long userId)
        {
            return await _userService.GetUserLocleAsync(userId);
        }

        [HttpPost("set-phoneNumber/{userId}/{phoneNumber}")]
        public async Task SetPhoneNumberAsync(long userId, string phoneNumber)
        {
            await _userService.SetPhoneNumberAsync(userId, phoneNumber);
        }

        [HttpPost("set-firstName/{userId}/{firstName}")]
        public async Task SetFirstNameAsync(long userId, string firstName)
        {
            await _userService.SetFirstNameAsync(userId, firstName);
        }

        [HttpPost("set-lastName/{userId}/{lastName}")]
        public async Task SetLastNameAsync(long userId, string lastName)
        {
            await _userService.SetLastNameAsync(userId, lastName);
        }

        [HttpPost("set-dayOfBirth")]
        public async Task SetBirthDayAsync([FromBody]UserDto user)
        {
            await _userService.SetBirthDayAsync(user.TelegramUserId, user.BirthDay);           
        }

        [HttpPost("set-registrationStatus/{userId}")]
        public async Task SetRegistrationStatusAsync(long userId)
        {
            await _userService.SetRegistrationStatusAsync(userId);
        }
        [HttpPost("set-trainingLevel/{userId}/{userLevel}")]
        public async Task SetTrainingLevel(long userId, int userLevel)
        {
            
            await _userService.SetTrainingLevel(userId, userLevel);
        }

    }
}
