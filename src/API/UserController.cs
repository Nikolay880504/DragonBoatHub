using Microsoft.AspNetCore.Mvc;
using DragonBoatHub.API.Application.Interfaces;
using DragonBoatHub.API.Application.Intrfaces;

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
        public async Task<IActionResult> CheckRegistractionByTelegramIdAsync(long? userId)
        {
            var IsAuthenticated = await _userService.CheckRegistractionByTelegramIdAsync(userId);

            return Ok(IsAuthenticated);
        }

        [HttpPost("set-locale/{telegramUserId}/{locale}")] 
        public async void SetUserLocaleAsync(long telegramUserId, string locale)
        {
              await _userService.SetUserLocaleAsync(telegramUserId, locale);
        }
        [HttpGet("get-locale/{telegramUserId}")]
        public async Task<string?> GetUserLocaleAsync(long telegramUserId)
        {
           return await _userService.GetUserLocleAsync(telegramUserId);
        }
        
    }
}
