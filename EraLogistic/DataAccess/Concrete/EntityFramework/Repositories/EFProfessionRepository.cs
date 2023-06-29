using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class ProfessionRepository : EFEntityRepositoryBase<Profession>, IProfesionRepository
    {
        public ProfessionRepository(DbContext context) : base(context)
        {
        }
    }
}
