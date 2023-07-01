using Entities.Concrete;

namespace Entities.DTOs.TeamDto
{
    public class TeamGetDto
    {
        public int Id { get; set; }

        public int ProfessionId { get; set; }
        public string Image { get; set; }
        public string Fullname { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string WhatsAppUrl { get; set; }
        public Profession Profession { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
