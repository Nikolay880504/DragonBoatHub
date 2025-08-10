using Microsoft.AspNetCore.Mvc;
using DragonBoatHub.API.Application.Interfaces;

namespace DragonBoatHub.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTrainingSessionController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public UserTrainingSessionController (ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet("available/{telegramUserId}")]
        public async Task<IActionResult> GetAvailableSessionsAsync(long telegramUserId)
        {
            var sessions = await _trainingService.GetAvailableSessionsAsync(telegramUserId);
            return Ok(sessions); 
        }

        [HttpPost("set-trainingForUser/{telegramUserId}/{trainingSessionId}")]
        public async Task SetTrainingSessionForUserAsync(long telegramUserId, long trainingSessionId)
        {
            await _trainingService.SetTrainingSessionForUserAsync (telegramUserId, trainingSessionId);
        }
    }
}
