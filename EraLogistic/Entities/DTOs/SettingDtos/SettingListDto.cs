using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.SettingDto
{
    public class SettingListDto : DtoGetBase
    {
        public IList<Setting> Settings { get; set; }
    }
}
