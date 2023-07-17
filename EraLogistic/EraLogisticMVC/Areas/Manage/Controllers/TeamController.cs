using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;
using DataAccess.Abstract;
using Entities.DTOs.ProfessionDto;
using Entities.DTOs.TeamDto;
using Microsoft.AspNetCore.Mvc;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IProfessionService _professionService;

        public TeamController(ITeamService teamService, IProfessionService professionService)
        {
            _teamService = teamService;
            _professionService = professionService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _teamService.GetAllByNonDeleted();

            return View(result.Data);
        }

        public async Task<IActionResult> DeletedTable()
        {
            var result = await _teamService.GetAllByDeleted();

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var professions = await _professionService.GetAllByNonDeleted();
            ViewBag.Professions = professions.Data;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TeamPostDto teamPostDto)
        {
            var professions = await _professionService.GetAllByNonDeleted();
            ViewBag.Professions = professions.Data;

            if (ModelState.IsValid)
            {
                var result = await _teamService.Add(teamPostDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Message = result.Message;
                    return RedirectToAction("index");
                }
            }

            return View(teamPostDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var professions = await _professionService.GetAllByNonDeleted();
            ViewBag.Professions = professions.Data;

            var result = await _teamService.GetUpdateDto(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TeamUpdateDto teamUpdateDto)
        {
            var professions = await _professionService.GetAllByNonDeleted();
            ViewBag.Professions = professions.Data;

            if (ModelState.IsValid)
            {
                var result = await _teamService.Update(teamUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("index");
                }
            }

            return View(teamUpdateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _teamService.Delete(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _teamService.HardDelete(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Restore(int id)
        {
            var result = await _teamService.Restore(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
