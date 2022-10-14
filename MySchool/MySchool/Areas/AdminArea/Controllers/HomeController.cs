using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class HomeController : Controller
    {
        private readonly ManagerSchoolContext _context;
        public HomeController(ManagerSchoolContext context)
        {
            _context = context;
        }
        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(MySchool.Models.Admin admin)
        {
            var check = _context.Admins.Where(x => x.Email == admin.Email && x.Password == admin.Password);
            if (check.Any())
            {
                // Add session
                HttpContext.Session.SetString("AdminSession", JsonConvert.SerializeObject(check.FirstOrDefault()));
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }
        public IActionResult Index()
        {
            if (CheckSession())
            {
                var check = JsonConvert.DeserializeObject<Models.Admin>(HttpContext.Session.GetString("AdminSession"));
                Models.Admin admin = check;
                return View(admin);
            }
            return View("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
