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

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableSessionsAsync()
        {
            var sessions = await _trainingService.GetAvailableSessionsAsync();
            return Ok(sessions); 
        }        
    }
}
