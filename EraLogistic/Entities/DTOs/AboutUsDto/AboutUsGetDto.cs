namespace Entities.DTOs.AboutUsDto
{
    public class AboutUsGetDto
    {
        public int Id { get; set; }

        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MissionDescription { get; set; }
        public string AdvantagesDescription { get; set; }
        public string GuaranteedDescription { get; set; }
        public string RedirectUrl { get; set; }
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
        public string Feature4 { get; set; }
        public string Feature5 { get; set; }
        public string Feature6 { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
