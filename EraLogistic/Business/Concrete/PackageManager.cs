using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDto;
using Entities.DTOs.PackageDto;
using Entities.DTOs.ProfessionDto;

namespace Business.Concrete
{
    public class PackageManager : IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PackageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(PackagePostDto packagePostDto)
        {
            if (packagePostDto != null)
            {
                var package = _mapper.Map<Package>(packagePostDto);

                await _unitOfWork.Packages.AddAsync(package);
                await _unitOfWork.SaveAsync();
                PackageGetDto packageGet = _mapper.Map<PackageGetDto>(package);
                return new Result(ResultStatus.Success, $"{packagePostDto.Name} paket uğurla əlavə edildi!");
            }

            return new Result(ResultStatus.Error, $"{packagePostDto.Name} paket əlavə edilmədi!");
        }

        public async Task<IResult> Delete(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                package.IsDeleted = true;
                await _unitOfWork.Packages.UpdateAsync(package);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{package.Name} paket uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Paket tapılmadı!");
        }

        public async Task<IDataResult<Package>> Get(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                return new DataResult<Package>(ResultStatus.Success, package);
            }
            return new DataResult<Package>(ResultStatus.Error, "Paket tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Package>>> GetAll()
        {
            var packages = await _unitOfWork.Packages.GetAllAsync();

            if (packages.Count >= 0)
            {
                return new DataResult<IList<Package>>(ResultStatus.Success, packages);
            }

            return new DataResult<IList<Package>>(ResultStatus.Error, "Paketlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Package>>> GetAllByDeleted()
        {
            var packages = await _unitOfWork.Packages.GetAllAsync(x => x.IsDeleted);

            if (packages.Count >= 0)
            {
                return new DataResult<IList<Package>>(ResultStatus.Success, packages);
            }

            return new DataResult<IList<Package>>(ResultStatus.Error, "Paketlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Package>>> GetAllByNonDeleted()
        {
            var packages = await _unitOfWork.Packages.GetAllAsync(x => !x.IsDeleted);

            if (packages.Count >= 0)
            {
                return new DataResult<IList<Package>>(ResultStatus.Success, packages);
            }

            return new DataResult<IList<Package>>(ResultStatus.Error, "Paketlər tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                await _unitOfWork.Packages.DeleteAsync(package);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{package.Name} paket uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Paket tapılmadı!");
        }

        public async Task<IResult> Restore(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                package.IsDeleted = false;
                await _unitOfWork.Packages.UpdateAsync(package);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{package.Name} paket uğurla geri qaytarıldı!");
            }

            return new Result(ResultStatus.Error, "Paket tapılmadı!");
        }

        public async Task<IResult> Update(PackageUpdateDto packageUpdateDto)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageUpdateDto.Id);

            if (package != null)
            {
                package.Name = packageUpdateDto.Name;
                package.Feature1 = packageUpdateDto.Feature1;
                package.Feature2 = packageUpdateDto.Feature2;
                package.Feature3 = packageUpdateDto.Feature3;
                package.Feature4 = packageUpdateDto.Feature4;
                package.Price = packageUpdateDto.Price;
                package.IsPopular = packageUpdateDto.IsPopular;
                package.IsMonthly = packageUpdateDto.IsMonthly;
                package.IsActive = packageUpdateDto.IsActive;
                package.ModifiedDate = DateTime.Now;

                await _unitOfWork.Packages.UpdateAsync(package);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{package.Name} paket uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Paket tapılmadı!");
        }
    }
}
