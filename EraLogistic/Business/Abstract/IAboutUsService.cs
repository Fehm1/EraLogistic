using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutUsDto;

namespace Business.Abstract
{
    public interface IAboutUsService 
    {
        Task<IDataResult<AboutUs>> Get(int AboutUsId);
        Task<IDataResult<IList<AboutUs>>> GetAll();
        Task<IResult> Add(AboutUsPostDto aboutUsAddDto);
        Task<IResult> Update(AboutUsUpdateDto aboutUsUpdateDto);
        Task<IResult> Delete(int AboutUsId);
        Task<IResult> HardDelete(int AboutUsId);
    }
}
