using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.SliderDto
{
    public class SliderDto : DtoGetBase
    {
        public Slider Slider { get; set; }
    }
}
