using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.PackageDto;
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
        public async Task<IDataResult<Setting>> Get(int settingId)
        {
            var setting = await _unitOfWork.Settings.GetAsync(x => x.Id == settingId);

            if (setting != null)
            {
                return new DataResult<Setting>(ResultStatus.Success, setting);
            }
            return new DataResult<Setting>(ResultStatus.Error, "Parametr tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Setting>>> GetAll()
        {
            var settings = await _unitOfWork.Settings.GetAllAsync();

            if (settings.Count >= 0)
            {
                return new DataResult<IList<Setting>>(ResultStatus.Success, settings);
            }

            return new DataResult<IList<Setting>>(ResultStatus.Error, "Parametrlər tapılmadı!", null);
        }

        public async Task<IResult> Update(SettingUpdateDto settingUpdateDto)
        {
            var setting = await _unitOfWork.Settings.GetAsync(x => x.Id == settingUpdateDto.Id);

            if (setting != null)
            {
                setting.Value = settingUpdateDto.Value;
                setting.ModifiedDate = DateTime.Now;

                await _unitOfWork.Settings.UpdateAsync(setting);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{setting.Key} uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Parametr tapılmadı!");
        }
    }
}
