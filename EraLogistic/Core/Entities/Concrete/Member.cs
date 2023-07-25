using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class Member : IdentityUser
    {
        public string RoleId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = false;
        public bool IsSuperAdmin { get; set; } = false;
    }
}
