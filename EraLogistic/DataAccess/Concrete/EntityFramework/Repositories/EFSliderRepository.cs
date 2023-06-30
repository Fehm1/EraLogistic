using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFSliderRepository : EFEntityRepositoryBase<Slider>, ISliderRepository
    {
        public EFSliderRepository(DbContext context) : base(context)
        {
        }
    }
}
