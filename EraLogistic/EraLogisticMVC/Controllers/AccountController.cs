using Microsoft.AspNetCore.Mvc;

namespace EraLogisticMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RegisterForUser()
        {
            return View();
        }

        public IActionResult RegisterForCompany()
        {
            return View();
        }
    }
}
