using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>();
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
