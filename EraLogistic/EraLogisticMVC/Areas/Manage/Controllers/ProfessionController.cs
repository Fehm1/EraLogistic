using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.DTOs.ProfessionDto;
using EraLogisticMVC.Areas.Manage.Model;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Extentions;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Razor;
using Core.Utilities.Results.Concrete;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProfessionController : Controller
    {
        private readonly IProfessionService _professionService;

        public ProfessionController(IProfessionService professionService)
        {
            _professionService = professionService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _professionService.GetAllByNonDeleted();

            return View(result.Data);
        }

        public async Task<IActionResult> DeletedTable()
        {
            var result = await _professionService.GetAllByDeleted();

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_ProfessionAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProfessionPostDto professionPostDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _professionService.Add(professionPostDto);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    var professionAddAjaxModel = JsonSerializer.Serialize(new ProfessionAddAjaxViewModel
                    {
                        ProfessionDto = result.Data,
                        ProfessionAddPartial = await this.RenderViewToStringAsync("_ProfessionAddPartial", professionPostDto)
                    });

                    return Json(professionAddAjaxModel);
                }
            }
            var professionAddAjaxErrorModel = JsonSerializer.Serialize(new ProfessionAddAjaxViewModel
            {
                ProfessionAddPartial = await this.RenderViewToStringAsync("_ProfessionAddPartial", professionPostDto)
            });

            return Json(professionAddAjaxErrorModel);

        }
    }
}
