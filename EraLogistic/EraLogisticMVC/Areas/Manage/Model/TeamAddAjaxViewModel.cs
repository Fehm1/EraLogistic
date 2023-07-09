using Entities.DTOs.TeamDto;

namespace EraLogisticMVC.Areas.Manage.Model
{
    public class TeamAddAjaxViewModel
    {
        public TeamPostDto TeamPostDto { get; set; }
        public string TeamAddPartial { get; set; }
        public TeamDto TeamDto { get; set; }
    }
}
