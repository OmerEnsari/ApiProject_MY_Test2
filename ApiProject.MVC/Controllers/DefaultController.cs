using Microsoft.AspNetCore.Mvc;

namespace ApiProject.MVC.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
