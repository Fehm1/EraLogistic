using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFTeamRepository : EFEntityRepositoryBase<Team>, ITeamRepository
    {
        public EFTeamRepository(DbContext context) : base(context)
        {
        }
    }
}
