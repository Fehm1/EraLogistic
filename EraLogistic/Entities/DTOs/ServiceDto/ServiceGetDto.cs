using Entities.Concrete;

namespace Entities.DTOs.ServiceDto
{
    public class ServiceGetDto
    {
        public int Id { get; set; }

        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
