using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Contact : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Messsage { get; set; }
        public string Email { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
