using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFPackageFeatureRepository : EFEntityRepositoryBase<PackageFeature>, IPackageFeatureRepository
    {
        public EFPackageFeatureRepository(DbContext context) : base(context)
        {
        }
    }
}
