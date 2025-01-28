using Microsoft.AspNetCore.Mvc;
using DragonBoatHub.API.Application.Interfaces;

namespace DragonBoatHub.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        public UserController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet("status/{userId}")]
        public async Task<IActionResult> CheckRegistractionByTelegramIdAsync(long? userId)
        {
            var IsAuthenticated = await _trainingService.CheckRegistractionByTelegramIdAsync(userId);

            return Ok(IsAuthenticated);
        }

        [HttpPost("set-locale/{telegramUserId}/{locale}")] 
        public async void SetUserLocaleAsync(long telegramUserId, string locale)
        {
   
        }
    }
}
