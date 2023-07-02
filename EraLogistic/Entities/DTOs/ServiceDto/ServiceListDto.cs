using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.ServiceDto
{
    public class ServiceListDto : DtoGetBase
    {
        public IList<Service> Services {  get; set; }
    }
}
