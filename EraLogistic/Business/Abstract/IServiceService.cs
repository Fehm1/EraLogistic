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
        Task<IDataResult<ServiceDto>> Add(ServicePostDto servicePostDto);
        Task<IDataResult<ServiceDto>> Update(ServiceUpdateDto serviceUpdateDto);
        Task<IDataResult<ServiceDto>> Restore(int serviceId);
        Task<IDataResult<ServiceDto>> Delete(int serviceId);
        Task<IDataResult<ServiceDto>> HardDelete(int serviceId);
    }
}
