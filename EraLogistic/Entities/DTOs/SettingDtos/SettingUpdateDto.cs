using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.SettingDto
{
    public class SettingUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Başlıq logo")]
        public IFormFile? HeaderLogoFile { get; set; }

        public string HeaderLogo { get; set; }

        [DisplayName("Sonluq logo")]
        public IFormFile? FooterLogoFile { get; set; }

        public string FooterLogo { get; set; }

        [DisplayName("Haqqımızda sarı başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string AboutUsYellowTitle { get; set; }

        [DisplayName("Haqqımızda ağ başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string AboutUsWhiteTitle { get; set; }

        [DisplayName("Haqqımızda açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string AboutUsDescription { get; set; }

        [DisplayName("Video üçün sarı başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string VideoYellowTitle { get; set; }

        [DisplayName("Video üçün ağ başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string VideoWhiteTitle { get; set; }

        [DisplayName("Video üçün kiçik açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string VideoLittleDescription { get; set; }

        [DisplayName("Video üçün açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string VideoDescription { get; set; }

        [DisplayName("Video linki")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string VideoLink { get; set; }

        [DisplayName("Servislər üçün sarı başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string OurServiceYellowTitle { get; set; }

        [DisplayName("Servislər üçün ağ başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string OurServiceWhiteTitle { get; set; }

        [DisplayName("Servislər üçün açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string OurServiceDescription { get; set; }

        [DisplayName("Paketlər üçün sarı başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string OurPackageYellowTitle { get; set; }

        [DisplayName("Paketlər üçün ağ başlıq")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string OurPackageWhiteTitle { get; set; }

        [DisplayName("Paketlər üçün açıqlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string OurPackageDescription { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Phone { get; set; }

        [DisplayName("Ünvan")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Address { get; set; }

        [DisplayName("Instagram")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Instagram { get; set; }

        [DisplayName("Facebook")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Facebook { get; set; }

        [DisplayName("Twitter")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Twitter { get; set; }

        [DisplayName("LinkedIn")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string LinkedIn { get; set; }

        [DisplayName("WhatsApp")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string WhatsApp { get; set; }

        [DisplayName("Youtube")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Youtube { get; set; }

        [DisplayName("Google maps linki")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(400, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string GoogleMapsLocation { get; set; }
    }
}
