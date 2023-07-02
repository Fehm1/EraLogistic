using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.SliderDto;

namespace Business.Abstract
{
    public interface ISliderService
    {
        Task<IDataResult<Slider>> Get(int sliderId);
        Task<IDataResult<IList<Slider>>> GetAll();
        Task<IDataResult<IList<Slider>>> GetAllByNonDeleted();
        Task<IDataResult<IList<Slider>>> GetAllByDeleted();
        Task<IResult> Add(SliderPostDto sliderPostDto);
        Task<IResult> Update(SliderUpdateDto sliderUpdateDto);
        Task<IResult> Restore(int sliderId);
        Task<IResult> Delete(int sliderId);
        Task<IResult> HardDelete(int sliderId);
    }
}
