using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DragonBoatHub.Admin.Areas.SuperUser.Pages
{
    [Authorize("AuthorizationUser")]
    public class AccountHomeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
