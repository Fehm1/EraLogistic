namespace Core.Entities.Concrete
{
    public class Member : BaseUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
    }
}
