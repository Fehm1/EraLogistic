using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.PackageDto
{
    public class PackageListDto : DtoGetBase
    {
        public IList<Package> Packages { get; set; }
    }
}
