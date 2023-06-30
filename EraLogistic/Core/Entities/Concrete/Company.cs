namespace Core.Entities.Concrete
{
    public class Company : BaseUser
    {
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyDescription { get; set; }
        public int StorageCount { get; set; }
    }
}
