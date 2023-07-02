using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.SettingDto
{
    public class SettingDto : DtoGetBase
    {
        public Setting Setting { get; set; }
    }
}
