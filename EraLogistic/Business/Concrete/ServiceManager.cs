using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public async Task<IDataResult<ServiceDto>> Add(ServicePostDto servicePostDto)
        {
            if (servicePostDto != null)
            {
                var service = _mapper.Map<Service>(servicePostDto);

                var addedService = await _unitOfWork.Services.AddAsync(service);
                await _unitOfWork.SaveAsync();
                ServiceDto serviceGetDto = _mapper.Map<ServiceDto>(service);

                return new DataResult<ServiceDto>(ResultStatus.Success, $"{addedService.Title} xidməti uğurla əlavə olundu!", new ServiceDto
                {
                    Service = addedService,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{addedService.Title} xidməti uğurla əlavə olundu!"
                });
            }

            return new DataResult<ServiceDto>(ResultStatus.Error, "Xidmət əlavə olunmadı!", new ServiceDto
            {
                Service = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmət tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceDto>> Delete(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                service.IsDeleted = true;
                var deletedService = await _unitOfWork.Services.UpdateAsync(service);
                await _unitOfWork.SaveAsync();

                return new DataResult<ServiceDto>(ResultStatus.Success, $"{deletedService.Title} xidməti uğurla silindi!", new ServiceDto
                {
                    Service = deletedService,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedService.Title} xidməti uğurla silindi!"
                });
            }

            return new DataResult<ServiceDto>(ResultStatus.Error, "Xidmət tapılmadı!", new ServiceDto
            {
                Service = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmət tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceDto>> Get(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                return new DataResult<ServiceDto>(ResultStatus.Success, new ServiceDto
                {
                    Service = service,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ServiceDto>(ResultStatus.Error, "Xidmət tapılmadı!", new ServiceDto
            {
                Service = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmət tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceListDto>> GetAll()
        {
            var services = await _unitOfWork.Services.GetAllAsync();

            if (services.Count >= 0)
            {
                return new DataResult<ServiceListDto>(ResultStatus.Success, new ServiceListDto
                {
                    Services = services,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ServiceListDto>(ResultStatus.Error, "Xidmətlər tapılmadı!", new ServiceListDto
            {
                Services = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmətlər tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceListDto>> GetAllByDeleted()
        {
            var services = await _unitOfWork.Services.GetAllAsync(x => x.IsDeleted);

            if (services.Count >= 0)
            {
                return new DataResult<ServiceListDto>(ResultStatus.Success, new ServiceListDto
                {
                    Services = services,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ServiceListDto>(ResultStatus.Error, "Xidmətlər tapılmadı!", new ServiceListDto
            {
                Services = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmətlər tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceListDto>> GetAllByNonDeleted()
        {
            var services = await _unitOfWork.Services.GetAllAsync(x => !x.IsDeleted);

            if (services.Count >= 0)
            {
                return new DataResult<ServiceListDto>(ResultStatus.Success, new ServiceListDto
                {
                    Services = services,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ServiceListDto>(ResultStatus.Error, "Xidmətlər tapılmadı!", new ServiceListDto
            {
                Services = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmətlər tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceDto>> HardDelete(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                var deletedService = await _unitOfWork.Services.DeleteAsync(service);
                await _unitOfWork.SaveAsync();

                return new DataResult<ServiceDto>(ResultStatus.Success, $"{deletedService.Title} xidməti uğurla silindi!", new ServiceDto
                {
                    Service = deletedService,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedService.Title} xidməti uğurla silindi!"
                });
            }

            return new DataResult<ServiceDto>(ResultStatus.Error, "Xidmət tapılmadı!", new ServiceDto
            {
                Service = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmət tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceDto>> Restore(int serviceId)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceId);

            if (service != null)
            {
                service.IsDeleted = false;
                var updatedService = await _unitOfWork.Services.UpdateAsync(service);
                await _unitOfWork.SaveAsync();

                return new DataResult<ServiceDto>(ResultStatus.Success, $"{updatedService.Title} xidməti uğurla geri qaytarıldı!", new ServiceDto
                {
                    Service = updatedService,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedService.Title} xidməti uğurla geri qaytarıldı!"
                });
            }

            return new DataResult<ServiceDto>(ResultStatus.Error, "Xidmət tapılmadı!", new ServiceDto
            {
                Service = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmət tapılmadı!"
            });
        }

        public async Task<IDataResult<ServiceDto>> Update(ServiceUpdateDto serviceUpdateDto)
        {
            var service = await _unitOfWork.Services.GetAsync(x => x.Id == serviceUpdateDto.Id);

            if (service != null)
            {
                service.Icon = serviceUpdateDto.Icon;
                service.Title = serviceUpdateDto.Title;
                service.Description = serviceUpdateDto.Description;
                service.IsActive = serviceUpdateDto.IsActive;
                service.ModifiedDate = DateTime.Now;

                var updatedService = await _unitOfWork.Services.UpdateAsync(service);
                await _unitOfWork.SaveAsync();

                return new DataResult<ServiceDto>(ResultStatus.Success, $"{updatedService.Title} xidməti uğurla yeniləndi!", new ServiceDto
                {
                    Service = updatedService,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedService.Title} xidməti uğurla yeniləndi!"
                });
            }

            return new DataResult<ServiceDto>(ResultStatus.Error, "Xidmət tapılmadı!", new ServiceDto
            {
                Service = null,
                ResultStatus = ResultStatus.Error,
                Message = "Xidmət tapılmadı!"
            });
        }
    }
}
