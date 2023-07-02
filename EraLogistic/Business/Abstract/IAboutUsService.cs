using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutUsDto;

namespace Business.Abstract
{
    public interface IAboutUsService
    {
        Task<IDataResult<AboutUsDto>> Get(int AboutUsId);
        Task<IResult> Update(AboutUsUpdateDto aboutUsUpdateDto);
    }
}
