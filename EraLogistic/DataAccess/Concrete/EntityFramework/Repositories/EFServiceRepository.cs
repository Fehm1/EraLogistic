using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFServiceRepository : EFEntityRepositoryBase<Service>, IServiceRepository
    {
        public EFServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
