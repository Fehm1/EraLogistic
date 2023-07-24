using Microsoft.AspNetCore.Mvc;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
