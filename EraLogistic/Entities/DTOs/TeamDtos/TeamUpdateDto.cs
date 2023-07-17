﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.TeamDto
{
    public class TeamUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Vəzifə")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        public int ProfessionId { get; set; }

        [DisplayName("Şəkil")]
        public IFormFile? ImageFile { get; set; }

        [DisplayName("Şəkil sətri")]
        public string Image { get; set; }

        [DisplayName("Ad, soyad")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(200, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Fullname { get; set; }

        [DisplayName("İnstagram")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string InstagramUrl { get; set; }

        [DisplayName("Facebook")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string FacebookUrl { get; set; }

        [DisplayName("Twitter")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string TwitterUrl { get; set; }

        [DisplayName("LinkedIn")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string LinkedInUrl { get; set; }

        [DisplayName("WhatsApp")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(100, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string WhatsAppUrl { get; set; }

        [DisplayName("Aktivdir?")]
        public bool IsActive { get; set; }
    }
}
