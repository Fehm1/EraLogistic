using Core.Utilities.Results.Abstract;
using Entities.DTOs.AboutUsDto;

namespace Business.Abstract
{
    public interface IAboutUsService
    {
        Task<IDataResult<AboutUsDto>> Get(int AboutUsId);
        Task<IDataResult<AboutUsUpdateDto>> GetUpdateDto(int AboutUsId);
        Task<IDataResult<AboutUsDto>> Update(AboutUsUpdateDto aboutUsUpdateDto);
    }
}
