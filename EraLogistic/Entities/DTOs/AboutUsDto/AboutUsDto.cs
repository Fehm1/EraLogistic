using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.AboutUsDto
{
    public class AboutUsDto : DtoGetBase
    {
        public AboutUs AboutUs { get; set; }
    }
}
