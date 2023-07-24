using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>();
            serviceCollection.AddIdentity<BaseUser, IdentityRole>(options =>
            {
                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddScoped<IAboutUsService, AboutUsManager>();
            serviceCollection.AddScoped<IContactService, ContactManager>();
            serviceCollection.AddScoped<IPackageService, PackageManager>();
            serviceCollection.AddScoped<IProfessionService, ProfessionManager>();
            serviceCollection.AddScoped<IServiceService, ServiceManager>();
            serviceCollection.AddScoped<ISettingService, SettingManager>();
            serviceCollection.AddScoped<ISliderService, SliderManager>();
            serviceCollection.AddScoped<ITeamService, TeamManager>();
            return serviceCollection;
        }
    }
}
