using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DragonBoatHub.Admin.Areas.SuperUser.Pages.Models;
using DragonBoatHub.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using DragonBoatHub.Admin.HttpClient;

namespace DragonBoatHub.Admin.Areas.SuperUser.Pages
{
    public class NewTrainingModel : PageModel
    {
        private readonly ITrainingManagementApiClient _trainingManagementApiClient;

        public NewTrainingModel(ITrainingManagementApiClient trainingManagementApiClient)
        {
            _trainingManagementApiClient = trainingManagementApiClient;
        }

        [BindProperty]
        public DateOnly Date { get; set; } =  DateOnly.FromDateTime(DateTime.Now);


        [BindProperty]
        public TimeOnly Time { get; set; }
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive number greater than zero.")]
        public int Capacity { get; set; }

        [BindProperty]
        public EAdminUserTrainingLevelDto Level { get; set; }
        [BindProperty]
        public int IdAgeCategory { get; set; } = 0;

        private static readonly List<UserAgeCategoryModel> _userAgeCategoryList = new List<UserAgeCategoryModel>
        {
                new() { Id = 0, Label = "No Category",MinAge = 0,MaxAge = 100 },
                new() { Id = 1, Label = "<15",MinAge = 0, MaxAge = 15 },
                new() { Id = 2, Label = "16-18",MinAge = 16, MaxAge = 18 },
                new() { Id = 3, Label = "19-39", MinAge = 19, MaxAge = 39 },
                new() { Id = 4, Label = "40-49", MinAge = 40, MaxAge = 49 },
                new() { Id = 5, Label = "50-59", MinAge = 50, MaxAge = 59 },
                new() { Id = 6, Label = "40+", MinAge = 40, MaxAge = 100 },
                new() { Id = 7, Label = "60+", MinAge = 60, MaxAge = 100 }
        };

        public static List<SelectListItem> AgeCategorySelectList { get; set; }
        static NewTrainingModel()
        {
            AgeCategorySelectList = _userAgeCategoryList
                 .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Label })
                 .ToList();
            {
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var userAgeCategory = _userAgeCategoryList.FirstOrDefault(c => c.Id == IdAgeCategory);
            var trainingSession = new TrainingSessionRequestDto
            {
                TrainingDateTime = Date.ToDateTime(Time),
                Capacity = Capacity,
                Level = (int)Level,
                MaxAge = userAgeCategory!.MaxAge,
                MinAge = userAgeCategory!.MinAge
            };

            await _trainingManagementApiClient.SaveNewTrainingSessionAsync(trainingSession);
            return RedirectToPage("AddTrainingSuccess");
        }
    }
}

