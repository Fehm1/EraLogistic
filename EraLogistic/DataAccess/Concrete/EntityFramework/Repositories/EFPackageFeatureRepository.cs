using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class PackageFeatureRepository : EFEntityRepositoryBase<PackageFeature>, IPackageFeatureRepository
    {
        public PackageFeatureRepository(DbContext context) : base(context)
        {
        }
    }
}
