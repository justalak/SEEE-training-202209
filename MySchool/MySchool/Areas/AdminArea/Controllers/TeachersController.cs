using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeachersController : Controller
    {
        private readonly ManagerSchoolContext _context;
        public TeachersController(ManagerSchoolContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            return View(await _context.Teachers.OrderBy(x => x.IdTeacher).ToListAsync());
        }
        public IActionResult Create()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            if (ModelState.IsValid)
            {
                if (teacher == null)
                {
                    ModelState.AddModelError("", "Error Add");
                    return View(teacher);
                }
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Added";
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            if (ModelState.IsValid)
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Teacher edited";
                return RedirectToAction("Edit", new { id = teacher.IdTeacher });
            }
            return View(teacher);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                TempData["Error"] = "Error delete";
            }
            else
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Successfully deleted";
            }
            return RedirectToAction("Index");
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
