using DragonBoatHub.Admin.Areas.SuperUser;
using DragonBoatHub.Admin.HttpClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;

namespace DragonBoatHub.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
         { 
            options.LoginPath = new PathString("/login");
         // options.LogoutPath = "/Logout";  // Страница выхода            
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
          }); 
            builder.Services.AddRefitClient<ITrainingManagementApiClient>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288"));
            builder.Services.Configure<CredentialsOptions>(
            builder.Configuration.GetSection("Credentials"));

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthorizationUser", policy => policy.RequireAuthenticatedUser());
            });


            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
