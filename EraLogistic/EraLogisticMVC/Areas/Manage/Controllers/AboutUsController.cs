using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.DTOs.AboutUsDto;
using Entities.DTOs.TeamDto;
using Microsoft.AspNetCore.Mvc;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _aboutUsService.Get(1);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _aboutUsService.GetUpdateDto(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUsUpdateDto aboutUsUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _aboutUsService.Update(aboutUsUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("index");
                }
            }

            return View(aboutUsUpdateDto);
        }
    }
}
