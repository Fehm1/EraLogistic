using Core.Data.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IServiceRepository : IEntityRepository<Service>
    {
    }
}
