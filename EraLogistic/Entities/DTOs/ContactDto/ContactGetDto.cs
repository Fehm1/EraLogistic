namespace Entities.DTOs.ContactDto
{
    public class ContactGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Messsage { get; set; }
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
