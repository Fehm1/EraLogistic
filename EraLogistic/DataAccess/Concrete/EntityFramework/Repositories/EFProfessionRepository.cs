using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFProfessionRepository : EFEntityRepositoryBase<Profession>, IProfesionRepository
    {
        public EFProfessionRepository(DbContext context) : base(context)
        {
        }
    }
}
