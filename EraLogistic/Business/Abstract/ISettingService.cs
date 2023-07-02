using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.SettingDto;

namespace Business.Abstract
{
    public interface ISettingService
    {
        Task<IDataResult<Setting>> Get(int settingId);
        Task<IDataResult<IList<Setting>>> GetAll();
        Task<IResult> Update(SettingUpdateDto settingUpdateDto);
    }
}
