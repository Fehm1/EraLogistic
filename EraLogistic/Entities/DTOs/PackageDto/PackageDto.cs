using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.PackageDto
{
    public class PackageDto : DtoGetBase
    {
        public Package Package { get; set; }
    }
}
