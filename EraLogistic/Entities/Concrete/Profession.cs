using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Profession : EntityBase, IEntity
    {
        public string ProfessionName { get; set; }

        public List<Team> Teams { get; set; }
    }
}
