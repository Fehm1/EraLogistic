using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.PackageDto
{
    public class PackageUpdateDto
    {
        [Required]
        public int Id { get; set; } 

        [DisplayName("Paket adı")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Name { get; set; }

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

        [DisplayName("Qiymət")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} müsbət ədəd daxil edin!")]
        public double Price { get; set; }

        [DisplayName("Populyardır?")]
        public bool IsPopular { get; set; }

        [DisplayName("Aylıqdır?")]
        public bool IsMonthly { get; set; }

        [DisplayName("Ünvanlama")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(200, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string RedirectUrl { get; set; }

        [DisplayName("Aktivdir?")]
        public bool IsActive { get; set; }
    }
}
