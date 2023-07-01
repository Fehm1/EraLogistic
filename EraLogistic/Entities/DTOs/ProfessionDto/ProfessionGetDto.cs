using Entities.Concrete;

namespace Entities.DTOs.ProfessionDto
{
    public class ProfessionGetDto
    {
        public int Id { get; set; }

        public string ProfessionName { get; set; }
        public List<Team> Teams { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
