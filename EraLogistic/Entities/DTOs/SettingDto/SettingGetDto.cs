namespace Entities.DTOs.SettingDto
{
    public class SettingGetDto
    {
        public int Id { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
