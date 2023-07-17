using Core.Utilities.Results.Abstract;
using Entities.DTOs.SettingDto;

namespace Business.Abstract
{
    public interface ISettingService
    {
        Task<IDataResult<SettingDto>> Get(int settingId);
        Task<IDataResult<SettingUpdateDto>> GetUpdateDto(int settingId);
        Task<IDataResult<SettingDto>> Update(SettingUpdateDto settingUpdateDto);
    }
}
