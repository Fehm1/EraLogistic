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
        Task<IDataResult<SliderDto>> Add(SliderPostDto sliderPostDto);
        Task<IDataResult<SliderDto>> Update(SliderUpdateDto sliderUpdateDto);
        Task<IDataResult<SliderDto>> Restore(int sliderId);
        Task<IDataResult<SliderDto>> Delete(int sliderId);
        Task<IDataResult<SliderDto>> HardDelete(int sliderId);
    }
}
