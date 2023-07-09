using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.DTOs.TeamDto;
using EraLogisticMVC.Areas.Manage.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core.Utilities.Extentions;
using DataAccess.Abstract;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(ITeamService teamService, IUnitOfWork unitOfWork)
        {
            _teamService = teamService;
            _unitOfWork = unitOfWork;
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Professions = await _unitOfWork.Professions.GetAllAsync(x => x.IsDeleted == false);

            return PartialView("_TeamAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeamPostDto teamPostDto)
        {
            ViewBag.Professions = await _unitOfWork.Professions.GetAllAsync(x => x.IsDeleted == false);

            if (ModelState.IsValid)
            {
                var result = await _teamService.Add(teamPostDto);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    var teamAddAjaxModel = JsonSerializer.Serialize(new TeamAddAjaxViewModel
                    {
                        TeamDto = result.Data,
                        TeamAddPartial = await this.RenderViewToStringAsync("_TeamAddPartial", teamPostDto)
                    });

                    return Json(teamAddAjaxModel);
                }
            }
            var teamAddAjaxErrorModel = JsonSerializer.Serialize(new TeamAddAjaxViewModel
            {
                TeamAddPartial = await this.RenderViewToStringAsync("_TeamAddPartial", teamPostDto)
            });

            return Json(teamAddAjaxErrorModel);

        }
    }
}
