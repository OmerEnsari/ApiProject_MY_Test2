using Microsoft.AspNetCore.Mvc;

namespace ApiProject.MVC.ViewComponents
{
    public class _HeadDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
