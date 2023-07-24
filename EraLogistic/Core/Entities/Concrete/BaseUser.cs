using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class BaseUser : IdentityUser
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
