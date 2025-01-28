using Microsoft.AspNetCore.Mvc;
using DragonBoatHub.API.Application.Interfaces;

namespace DragonBoatHub.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingSessionsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingSessionsController (ITrainingService trainingService)
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
