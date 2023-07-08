using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.ServiceDto
{
    public class ServiceDto : DtoGetBase
    {
        public Service Service { get; set; }
    }
}
