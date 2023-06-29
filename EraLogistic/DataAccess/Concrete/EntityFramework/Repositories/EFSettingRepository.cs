using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class SettingRepository : EFEntityRepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(DbContext context) : base(context)
        {
        }
    }
}
