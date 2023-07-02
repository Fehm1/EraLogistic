using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.PackageDto;

namespace Business.Abstract
{
    public interface IPackageService
    {
        Task<IDataResult<Package>> Get(int packageId);
        Task<IDataResult<IList<Package>>> GetAll();
        Task<IDataResult<IList<Package>>> GetAllByNonDeleted();
        Task<IDataResult<IList<Package>>> GetAllByDeleted();
        Task<IResult> Add(PackagePostDto packagePostDto);
        Task<IResult> Update(PackageUpdateDto packageUpdateDto);
        Task<IResult> Restore(int packageId);
        Task<IResult> Delete(int packageId);
        Task<IResult> HardDelete(int packageId);
    }
}
