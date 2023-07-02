using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.PackageDto;
using Entities.DTOs.ProfessionDto;
using Entities.DTOs.ServiceDto;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ServicePostDto servicePostDto)
        {
            if (servicePostDto != null)
            {
                var service = _mapper.Map<Service>(servicePostDto);

                await _unitOfWork.Services.AddAsync(service);
                await _unitOfWork.SaveAsync();
                ServiceGetDto serviceGetDto = _mapper.Map<ServiceGetDto>(service);

                return new Result(ResultStatus.Success, $"{servicePostDto.Title} uğurla əlavə olundu!");
            }

            return new Result(ResultStatus.Error, "Xidmət əlavə olunmadı!");
        }

        public async Task<IResult> Delete(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                service.IsDeleted = true;
                await _unitOfWork.Services.UpdateAsync(service);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Xidmət uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Xidmət tapılmadı!");
        }

        public async Task<IDataResult<Service>> Get(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                return new DataResult<Service>(ResultStatus.Success, service);
            }
            return new DataResult<Service>(ResultStatus.Error, "Xidmət tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Service>>> GetAll()
        {
            var services = await _unitOfWork.Services.GetAllAsync();

            if (services.Count >= 0)
            {
                return new DataResult<IList<Service>>(ResultStatus.Success, services);
            }

            return new DataResult<IList<Service>>(ResultStatus.Error, "Xidmətlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Service>>> GetAllByDeleted()
        {
            var services = await _unitOfWork.Services.GetAllAsync(x => x.IsDeleted);

            if (services.Count >= 0)
            {
                return new DataResult<IList<Service>>(ResultStatus.Success, services);
            }

            return new DataResult<IList<Service>>(ResultStatus.Error, "Xidmətlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Service>>> GetAllByNonDeleted()
        {
            var services = await _unitOfWork.Services.GetAllAsync(x => !x.IsDeleted);

            if (services.Count >= 0)
            {
                return new DataResult<IList<Service>>(ResultStatus.Success, services);
            }

            return new DataResult<IList<Service>>(ResultStatus.Error, "Xidmətlər tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                await _unitOfWork.Services.DeleteAsync(service);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Xidmət uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Xidmət tapılmadı!");
        }

        public async Task<IResult> Restore(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                service.IsDeleted = false;
                await _unitOfWork.Services.UpdateAsync(service);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Xidmət uğurla geri qaytarıldı!");
            }

            return new Result(ResultStatus.Error, "Xidmət tapılmadı!");
        }

        public async Task<IResult> Update(ServiceUpdateDto serviceUpdateDto)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceUpdateDto.Id);

            if (service != null)
            {
                service.Icon = serviceUpdateDto.Icon;
                service.Title = serviceUpdateDto.Title;
                service.Description = serviceUpdateDto.Description;
                service.IsActive = serviceUpdateDto.IsActive;
                service.ModifiedDate = DateTime.Now;

                await _unitOfWork.Services.UpdateAsync(service);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{service.Title} xidmət uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Xidmət tapılmadı!");
        }
    }
}
