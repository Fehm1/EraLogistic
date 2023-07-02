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
        Task<IResult> Add(PackagePostDto packagePostDto);
        Task<IResult> Update(PackageUpdateDto packageUpdateDto);
        Task<IResult> Restore(int packageId);
        Task<IResult> Delete(int packageId);
        Task<IResult> HardDelete(int packageId);
    }
}
