using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DragonBoatHub.Admin.Areas.SuperUser.Pages
{
    [Authorize("AuthorizationUser")]
    public class TrainingFormModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
