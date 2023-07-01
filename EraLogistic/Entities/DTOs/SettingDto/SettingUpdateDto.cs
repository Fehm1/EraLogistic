using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.SettingDto
{
    public class SettingUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Key")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Key { get; set; }

        [DisplayName("Value")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Value { get; set; }

        [DisplayName("Aktivdir?")]
        public bool IsActive { get; set; }
    }
}
