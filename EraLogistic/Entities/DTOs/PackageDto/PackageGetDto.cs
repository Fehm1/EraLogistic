using Entities.Concrete;

namespace Entities.DTOs.PackageDto
{
    public class PackageGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
        public string Feature4 { get; set; }
        public double Price { get; set; }
        public int SaleCount { get; set; }
        public bool IsPopular { get; set; }
        public bool IsMonthly { get; set; }
        public string RedirectUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
