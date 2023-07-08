using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.ProfessionDto
{
    public class ProfessionUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Vəzifə")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string ProfessionName { get; set; }

        [DisplayName("Aktivdir?")]
        public bool IsActive { get; set; }
    }
}
