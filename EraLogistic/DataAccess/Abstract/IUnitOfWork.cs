namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAboutUsRepository AboutUs { get; }
        IContactRepository Contacts { get; }
        IPackageFeatureRepository PackageFeatures { get; }
        IPackageRepository Packages { get; }
        IProfesionRepository Professions { get; }
        IServiceRepository Services { get; }
        ISettingRepository Settings { get; }
        ISliderRepository Sliders { get; }
        ITeamRepository Teams { get; }
        Task<int> SaveAsync();
    }
}
