using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ServiceDto;

namespace Business.Abstract
{
    public interface IServiceService
    {
        Task<IDataResult<ServiceDto>> Get(int serviceId);
        Task<IDataResult<ServiceListDto>> GetAll();
        Task<IDataResult<ServiceListDto>> GetAllByNonDeleted();
        Task<IDataResult<ServiceListDto>> GetAllByDeleted();
        Task<IResult> Add(ServicePostDto servicePostDto);
        Task<IResult> Update(ServiceUpdateDto serviceUpdateDto);
        Task<IResult> Restore(int serviceId);
        Task<IResult> Delete(int serviceId);
        Task<IResult> HardDelete(int serviceId);
    }
}
