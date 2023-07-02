using Core.Utilities.Results.Abstract;
using Entities.DTOs.SliderDto;

namespace Business.Abstract
{
    public interface ISliderService
    {
        Task<IDataResult<SliderDto>> Get(int sliderId);
        Task<IDataResult<SliderListDto>> GetAll();
        Task<IDataResult<SliderListDto>> GetAllByNonDeleted();
        Task<IDataResult<SliderListDto>> GetAllByDeleted();
        Task<IResult> Add(SliderPostDto sliderPostDto);
        Task<IResult> Update(SliderUpdateDto sliderUpdateDto);
        Task<IResult> Restore(int sliderId);
        Task<IResult> Delete(int sliderId);
        Task<IResult> HardDelete(int sliderId);
    }
}
