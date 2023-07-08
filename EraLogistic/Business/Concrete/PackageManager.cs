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

        public async Task<IDataResult<PackageDto>> Add(PackagePostDto packagePostDto)
        {
            if (packagePostDto != null)
            {
                var package = _mapper.Map<Package>(packagePostDto);

                var addedPackage = await _unitOfWork.Packages.AddAsync(package);
                await _unitOfWork.SaveAsync();
                PackageDto packageGet = _mapper.Map<PackageDto>(package);
                return new DataResult<PackageDto>(ResultStatus.Success, $"{packagePostDto.Name} paket uğurla əlavə edildi!", new PackageDto
                {
                    Package = addedPackage,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{packagePostDto.Name} paket uğurla əlavə edildi!"
                });
            }

            return new DataResult<PackageDto>(ResultStatus.Error, $"{packagePostDto.Name} paket əlavə edilmədi!", new PackageDto
            {
                Package = null,
                ResultStatus = ResultStatus.Error,
                Message = $"{packagePostDto.Name} paket əlavə edilmədi!"
            });
        }

        public async Task<IDataResult<PackageDto>> Delete(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                package.IsDeleted = true;
                var deletedPackage = await _unitOfWork.Packages.UpdateAsync(package);
                await _unitOfWork.SaveAsync();

                return new DataResult<PackageDto>(ResultStatus.Success, $"{package.Name} paket uğurla silindi!", new PackageDto
                {
                    Package = deletedPackage,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{package.Name} paket uğurla silindi!"
                });
            }

            return new DataResult<PackageDto>(ResultStatus.Error, "Paket tapılmadı!", new PackageDto
            {
                Package = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paket tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageDto>> Get(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                return new DataResult<PackageDto>(ResultStatus.Success, new PackageDto
                {
                    Package = package,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PackageDto>(ResultStatus.Error, "Paket tapılmadı!", new PackageDto
            {
                Package = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paket tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageListDto>> GetAll()
        {
            var packages = await _unitOfWork.Packages.GetAllAsync();

            if (packages.Count >= 0)
            {
                return new DataResult<PackageListDto>(ResultStatus.Success, new PackageListDto
                {
                    Packages = packages,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<PackageListDto>(ResultStatus.Error, "Paketlər tapılmadı!", new PackageListDto
            {
                Packages = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paketlər tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageListDto>> GetAllByDeleted()
        {
            var packages = await _unitOfWork.Packages.GetAllAsync(x => x.IsDeleted);

            if (packages.Count >= 0)
            {
                return new DataResult<PackageListDto>(ResultStatus.Success, new PackageListDto
                {
                    Packages = packages,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<PackageListDto>(ResultStatus.Error, "Paketlər tapılmadı!", new PackageListDto
            {
                Packages = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paketlər tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageListDto>> GetAllByNonDeleted()
        {
            var packages = await _unitOfWork.Packages.GetAllAsync(x => !x.IsDeleted);

            if (packages.Count >= 0)
            {
                return new DataResult<PackageListDto>(ResultStatus.Success, new PackageListDto
                {
                    Packages = packages,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<PackageListDto>(ResultStatus.Error, "Paketlər tapılmadı!", new PackageListDto
            {
                Packages = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paketlər tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageDto>> HardDelete(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                var deletedPackage = await _unitOfWork.Packages.DeleteAsync(package);
                await _unitOfWork.SaveAsync();

                return new DataResult<PackageDto>(ResultStatus.Success, $"{package.Name} paket uğurla silindi!", new PackageDto
                {
                    Package = deletedPackage,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{package.Name} paket uğurla silindi!"
                });
            }

            return new DataResult<PackageDto>(ResultStatus.Error, "Paket tapılmadı!", new PackageDto
            {
                Package = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paket tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageDto>> Restore(int packageId)
        {
            var package = await _unitOfWork.Packages.GetAsync(x => x.Id == packageId);

            if (package != null)
            {
                package.IsDeleted = false;
                var updatedPackage = await _unitOfWork.Packages.UpdateAsync(package);
                await _unitOfWork.SaveAsync();

                return new DataResult<PackageDto>(ResultStatus.Success, $"{updatedPackage.Name} paket uğurla geri qaytarıldı!", new PackageDto
                {
                    Package = updatedPackage,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedPackage.Name} paket uğurla geri qaytarıldı!"
                });
            }

            return new DataResult<PackageDto>(ResultStatus.Error, "Paket tapılmadı!", new PackageDto
            {
                Package = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paket tapılmadı!"
            });
        }

        public async Task<IDataResult<PackageDto>> Update(PackageUpdateDto packageUpdateDto)
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

                var updatedPackage = await _unitOfWork.Packages.UpdateAsync(package);
                await _unitOfWork.SaveAsync();

                return new DataResult<PackageDto>(ResultStatus.Success, $"{updatedPackage.Name} paket uğurla yeniləndi!", new PackageDto
                {
                    Package = updatedPackage,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedPackage.Name} paket uğurla yeniləndi!"
                });
            }

            return new DataResult<PackageDto>(ResultStatus.Error, "Paket tapılmadı!", new PackageDto
            {
                Package = null,
                ResultStatus = ResultStatus.Error,
                Message = "Paket tapılmadı!"
            });
        }
    }
}
