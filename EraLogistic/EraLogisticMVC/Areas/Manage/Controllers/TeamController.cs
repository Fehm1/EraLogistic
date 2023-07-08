using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Mvc;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _teamService.GetAllByNonDeleted();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }
    }
}
