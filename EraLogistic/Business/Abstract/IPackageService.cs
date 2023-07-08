using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.PackageDto;

namespace Business.Abstract
{
    public interface IPackageService
    {
        Task<IDataResult<PackageDto>> Get(int packageId);
        Task<IDataResult<PackageListDto>> GetAll();
        Task<IDataResult<PackageListDto>> GetAllByNonDeleted();
        Task<IDataResult<PackageListDto>> GetAllByDeleted();
        Task<IDataResult<PackageDto>> Add(PackagePostDto packagePostDto);
        Task<IDataResult<PackageDto>> Update(PackageUpdateDto packageUpdateDto);
        Task<IDataResult<PackageDto>> Restore(int packageId);
        Task<IDataResult<PackageDto>> Delete(int packageId);
        Task<IDataResult<PackageDto>> HardDelete(int packageId);
    }
}
