using Core.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Profession : EntityBase, IEntity
    {
        public string ProfessionName { get; set; }

        public List<Team> Teams { get; set; }
    }
}
