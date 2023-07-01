using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.SettingDto
{
    public class SettingPostDto
    {
        [DisplayName("Key")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Key { get; set; }

        [DisplayName("Value")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Value { get; set; }
    }
}
