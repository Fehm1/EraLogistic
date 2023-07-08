using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.SettingDto;

namespace Business.Abstract
{
    public interface ISettingService
    {
        Task<IDataResult<SettingDto>> Get(int settingId);
        Task<IDataResult<SettingListDto>> GetAll();
        Task<IDataResult<SettingDto>> Update(SettingUpdateDto settingUpdateDto);
    }
}
