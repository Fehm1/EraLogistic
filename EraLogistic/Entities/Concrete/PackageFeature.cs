using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class PackageFeature : EntityBase, IEntity
    {
        public int PackageId { get; set; }
        public string Feature { get; set; }

        public Package Package { get; set; }
    }
}
