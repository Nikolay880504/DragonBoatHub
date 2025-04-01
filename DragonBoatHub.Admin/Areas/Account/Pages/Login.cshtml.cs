using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using DragonBoatHub.Admin.Areas.SuperUser;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace DragonBoatHub.Admin.Areas.Account.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CredentialsOptions _options;

        public LoginModel(IOptions<CredentialsOptions> options)
        {
            _options = options.Value;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                if (UserName.Equals(_options.Login) && Password.Equals(_options.Password))
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, UserName),
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true 
                    };                
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                    if (!string.IsNullOrEmpty(returnUrl) && returnUrl != "/")
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/AccountHome");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
            }
            return Page();
        }

    }
}
