using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.ContactDto
{
    public class ContactPostDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(150, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Surname { get; set; }

        [DisplayName("Mesaj")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Messsage { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(150, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Email { get; set; }
    }
}
