using Microsoft.AspNetCore.Mvc;

namespace MySchool.Areas.Admin.Controllers
{
    [Area("AdminArea")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
