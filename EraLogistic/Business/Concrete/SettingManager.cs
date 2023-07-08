using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs.SettingDto;

namespace Business.Concrete
{
    public class SettingManager : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<SettingDto>> Get(int settingId)
        {
            var setting = await _unitOfWork.Settings.GetAsync(x => x.Id == settingId);

            if (setting != null)
            {
                return new DataResult<SettingDto>(ResultStatus.Success, new SettingDto
                {
                    Setting = setting,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SettingDto>(ResultStatus.Error, "Parametr tapılmadı!", new SettingDto
            {
                Setting = null,
                ResultStatus = ResultStatus.Error,
                Message = "Parametr tapılmadı!"
            });
        }

        public async Task<IDataResult<SettingListDto>> GetAll()
        {
            var settings = await _unitOfWork.Settings.GetAllAsync();

            if (settings.Count >= 0)
            {
                return new DataResult<SettingListDto>(ResultStatus.Success, new SettingListDto
                {
                    Settings = settings,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<SettingListDto>(ResultStatus.Error, "Parametrlər tapılmadı!", new SettingListDto
            {
                Settings = null,
                ResultStatus = ResultStatus.Error,
                Message = "Parametrlər tapılmadı!"
            });
        }

        public async Task<IDataResult<SettingDto>> Update(SettingUpdateDto settingUpdateDto)
        {
            var setting = await _unitOfWork.Settings.GetAsync(x => x.Id == settingUpdateDto.Id);

            if (setting != null)
            {
                setting.Value = settingUpdateDto.Value;
                setting.ModifiedDate = DateTime.Now;

                var updatedSetting = await _unitOfWork.Settings.UpdateAsync(setting);
                await _unitOfWork.SaveAsync();

                return new DataResult<SettingDto>(ResultStatus.Success, $"{updatedSetting.Key} uğurla yeniləndi!", new SettingDto
                {
                    Setting = updatedSetting,
                    ResultStatus= ResultStatus.Success,
                    Message = $"{updatedSetting.Key} uğurla yeniləndi!"
                });
            }

            return new DataResult<SettingDto>(ResultStatus.Error, "Parametr tapılmadı!", new SettingDto
            {
                Setting = null,
                ResultStatus = ResultStatus.Error,
                Message = "Parametr tapılmadı!"
            });
        }
    }
}
