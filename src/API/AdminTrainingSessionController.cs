
using Microsoft.AspNetCore.Mvc;
using DragonBoatHub.Contracts;
using DragonBoatHub.API.Application.Intrfaces;

namespace DragonBoatHub.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminTrainingSessionController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminTrainingSessionController(IAdminService adminService) {

            _adminService = adminService;
        }
        [HttpPost("save-newTrainingSession")]
        public async Task  SaveNewTrainingSessionAsync([FromBody] TrainingSessionRequestDto sessionRequestDto)
        {

            await _adminService.SaveNewTrainingSessionAsync(sessionRequestDto);
        }
    }
}

