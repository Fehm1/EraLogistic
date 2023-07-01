using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProfessionDto;

namespace Business.Abstract
{
    public interface IProfessionService
    {
        Task<IDataResult<Profession>> Get(int professionId);
        Task<IDataResult<IList<Profession>>> GetAll();
        Task<IDataResult<IList<Profession>>> GetAllByNonDeleted();
        Task<IDataResult<IList<Profession>>> GetAllByDeleted();
        Task<IResult> Add(ProfessionPostDto professionPostDto);
        Task<IResult> Update(ProfessionUpdateDto professionUpdateDto);
        Task<IResult> Restore(int professionId);
        Task<IResult> Delete(int professionId);
        Task<IResult> HardDelete(int professionId);
    }
}
