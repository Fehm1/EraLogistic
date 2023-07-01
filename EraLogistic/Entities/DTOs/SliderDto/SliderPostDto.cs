using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.SliderDto
{
    public class SliderPostDto
    {
        [DisplayName("Şəkil")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        public IFormFile Image { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Title { get; set; }

        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(200, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Description { get; set; }

        [DisplayName("Ünvanlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(200, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string RedirectUrl { get; set; }
    }
}
