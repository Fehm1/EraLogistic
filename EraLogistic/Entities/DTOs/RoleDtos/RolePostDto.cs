﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.RoleDtos
{
    public  class RolePostDto
    {
        [DisplayName("Rol")]
        [Required(ErrorMessage = "{0} daxil edin!")]
        [MaxLength(200, ErrorMessage = "{0} {1} uzunluqdan az olmamalıdır!")]
        public string Name { get; set; }
    }
}
