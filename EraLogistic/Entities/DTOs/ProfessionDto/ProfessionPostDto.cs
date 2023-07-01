using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.ProfessionDto
{
    public class ProfessionPostDto
    {
        [DisplayName("Vəzifə")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string ProfessionName { get; set; }
    }
}
