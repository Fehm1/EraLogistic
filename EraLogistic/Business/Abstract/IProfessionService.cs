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
        Task<IDataResult<ProfessionDto>> Add(ProfessionPostDto professionPostDto);
        Task<IDataResult<ProfessionDto>> Update(ProfessionUpdateDto professionUpdateDto);
        Task<IDataResult<ProfessionDto>> Restore(int professionId);
        Task<IDataResult<ProfessionDto>> Delete(int professionId);
        Task<IDataResult<ProfessionDto>> HardDelete(int professionId);
    }
}
