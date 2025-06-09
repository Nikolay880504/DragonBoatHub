
using DragonBoatHub.API.Domain.Interfaces;
using DragonBoatHub.API.Application.Interfaces;
using DragonBoatHub.API.Application;
using DragonBoatHub.API.Infrastructure;
using DragonBoatHub.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using DragonBoatHub.API.Application.Intrfaces;


namespace DragonBoatHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options => 
                   options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
            builder.Services.AddScoped<ITrainingService, TrainingService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddControllers();  
            builder.WebHost.UseUrls("https://localhost:7288");

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();  

            app.Run();
        }
    }
}
