using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFSettingRepository : EFEntityRepositoryBase<Setting>, ISettingRepository
    {
        public EFSettingRepository(DbContext context) : base(context)
        {
        }
    }
}
