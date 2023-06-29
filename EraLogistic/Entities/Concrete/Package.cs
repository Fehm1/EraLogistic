using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Package : EntityBase, IEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int SaleCount { get; set; }
        public bool IsPopular { get; set; } = false;
        public bool IsMonthly { get; set; } = false;

        public ICollection<PackageFeature> PackageFeatures { get; set; }
    }
}
