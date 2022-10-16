using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;

namespace StudentManagement.Controllers
{
    public class ClassController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public ClassController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var classes = await mvcDbContext.Class.ToListAsync();
            return View(classes);
        }
    }
}
