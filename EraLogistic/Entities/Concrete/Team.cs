using Core.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Team : EntityBase, IEntity
    {
        public int ProfessionId { get; set; }
        public string Image { get; set; }
        public string Fullname { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string WhatsAppUrl { get; set; }

        public Profession Profession { get; set; }
    }
}
