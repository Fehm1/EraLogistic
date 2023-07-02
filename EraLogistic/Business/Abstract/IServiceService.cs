using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ServiceDto;

namespace Business.Abstract
{
    public interface IServiceService
    {
        Task<IDataResult<Service>> Get(int serviceId);
        Task<IDataResult<IList<Service>>> GetAll();
        Task<IDataResult<IList<Service>>> GetAllByNonDeleted();
        Task<IDataResult<IList<Service>>> GetAllByDeleted();
        Task<IResult> Add(ServicePostDto servicePostDto);
        Task<IResult> Update(ServiceUpdateDto serviceUpdateDto);
        Task<IResult> Restore(int serviceId);
        Task<IResult> Delete(int serviceId);
        Task<IResult> HardDelete(int serviceId);
    }
}
