using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.AboutUsDto
{
    public class AboutUsUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Şəkil")]
        public IFormFile Image { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(150, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Title { get; set; }

        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Description { get; set; }

        [DisplayName("Vəzifələr")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string MissionDescription { get; set; }

        [DisplayName("Üstünlüklər")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string AdvantagesDescription { get; set; }

        [DisplayName("Zəmanətlər")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string GuaranteedDescription { get; set; }

        [DisplayName("Ünvanlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(200, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string RedirectUrl { get; set; }

        [DisplayName("Xüsusiyyət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Feature1 { get; set; }

        [DisplayName("Xüsusiyyət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Feature2 { get; set; }

        [DisplayName("Xüsusiyyət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Feature3 { get; set; }

        [DisplayName("Xüsusiyyət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Feature4 { get; set; }

        [DisplayName("Xüsusiyyət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Feature5 { get; set; }

        [DisplayName("Xüsusiyyət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Feature6 { get; set; }


        [DisplayName("Aktivdir?")]
        public bool IsActive { get; set; }
    }
}
