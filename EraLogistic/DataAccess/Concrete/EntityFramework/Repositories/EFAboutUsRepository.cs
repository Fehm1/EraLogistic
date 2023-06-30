using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFAboutUsRepository : EFEntityRepositoryBase<AboutUs>, IAboutUsRepository
    {
        public EFAboutUsRepository(DbContext context) : base(context)
        {
        }
    }
}
