using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.SliderDto
{
    public class SliderListDto : DtoGetBase
    {
        public IList<Slider> Sliders { get; set; }
    }
}
