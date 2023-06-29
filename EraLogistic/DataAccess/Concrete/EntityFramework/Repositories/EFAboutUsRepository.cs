using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class AboutUsRepository : EFEntityRepositoryBase<AboutUs>, IAboutUsRepository
    {
        public AboutUsRepository(DbContext context) : base(context)
        {
        }
    }
}
