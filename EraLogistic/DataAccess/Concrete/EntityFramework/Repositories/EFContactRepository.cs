using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFContactRepository : EFEntityRepositoryBase<Contact>, IContactRepository
    {
        public EFContactRepository(DbContext context) : base(context)
        {
        }
    }
}
