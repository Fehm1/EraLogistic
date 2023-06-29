using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Setting : EntityBase, IEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
