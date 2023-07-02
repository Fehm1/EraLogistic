using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProfessionDto;

namespace Business.Abstract
{
    public interface IProfessionService
    {
        Task<IDataResult<ProfessionDto>> Get(int professionId);
        Task<IDataResult<ProfessionListDto>> GetAll();
        Task<IDataResult<ProfessionListDto>> GetAllByNonDeleted();
        Task<IDataResult<ProfessionListDto>> GetAllByDeleted();
        Task<IResult> Add(ProfessionPostDto professionPostDto);
        Task<IResult> Update(ProfessionUpdateDto professionUpdateDto);
        Task<IResult> Restore(int professionId);
        Task<IResult> Delete(int professionId);
        Task<IResult> HardDelete(int professionId);
    }
}
