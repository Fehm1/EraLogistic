using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class ContactRepository : EFEntityRepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(DbContext context) : base(context)
        {
        }
    }
}
