using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class ServiceRepository : EFEntityRepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
