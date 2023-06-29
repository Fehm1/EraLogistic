using Core.Data.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class SliderRepository : EFEntityRepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(DbContext context) : base(context)
        {
        }
    }
}
