using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İmplementations;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;

namespace Parfume.App.ServiceRegistration
{
    public static class ServiceRegister
    {
        public static void Register(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IMailService, MailService>();


            service.AddScoped<ISettingService, SettingService>();


            service.AddIdentity<AppUser, IdentityRole>()
                   .AddDefaultTokenProviders()
                   .AddEntityFrameworkStores<ParfumeDbContext>();
            service.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
            service.AddDbContext<ParfumeDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }
    }
}
