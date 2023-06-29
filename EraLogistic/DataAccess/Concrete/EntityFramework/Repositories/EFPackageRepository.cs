using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFPackageRepository : EFEntityRepositoryBase<Package>, IPackageRepository
    {
        public EFPackageRepository(DbContext context) : base(context)
        {
        }
    }
}
