using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly EFAboutUsRepository _efAboutUsRepository;
        private readonly EFContactRepository _efContactRepository;
        private readonly EFPackageRepository _efPackageRepository;
        private readonly EFProfessionRepository _efProfessionRepository;
        private readonly EFServiceRepository _efServiceRepository;
        private readonly EFSettingRepository _efSettingRepository;
        private readonly EFSliderRepository _efSliderRepository;
        private readonly EFTeamRepository _efTeamRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAboutUsRepository AboutUs => _efAboutUsRepository ?? new EFAboutUsRepository(_context);

        public IContactRepository Contacts => _efContactRepository ?? new EFContactRepository(_context);

        public IPackageRepository Packages => _efPackageRepository ?? new EFPackageRepository(_context);

        public IProfesionRepository Professions => _efProfessionRepository ?? new EFProfessionRepository(_context);

        public IServiceRepository Services => _efServiceRepository ?? new EFServiceRepository(_context);

        public ISettingRepository Settings => _efSettingRepository ?? new EFSettingRepository(_context);

        public ISliderRepository Sliders => _efSliderRepository ?? new EFSliderRepository(_context);

        public ITeamRepository Teams => _efTeamRepository ?? new EFTeamRepository(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
