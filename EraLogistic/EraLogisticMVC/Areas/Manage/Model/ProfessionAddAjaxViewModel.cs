using Entities.DTOs.ProfessionDto;

namespace EraLogisticMVC.Areas.Manage.Model
{
    public class ProfessionAddAjaxViewModel
    {
        public ProfessionPostDto ProfessionPostDto { get; set; }
        public string ProfessionAddPartial { get; set; }
        public ProfessionDto ProfessionDto { get; set; }
    }
}
