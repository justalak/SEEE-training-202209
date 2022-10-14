using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ClassesController : Controller
    {
        private readonly ManagerSchoolContext _context;
        public ClassesController(ManagerSchoolContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            return View(await _context.Classes.OrderBy(x => x.IdClass).ToListAsync());
        }
        public IActionResult Create()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            ViewBag.IdTeacher = new SelectList(_context.Teachers.OrderBy(x => x.IdTeacher), "IdTeacher", "NameTeacher");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Class cl)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            if (ModelState.IsValid)
            {
                if (cl == null)
                {
                    ModelState.AddModelError("", "Error Add");
                    return View(cl);
                }
                var nameUnique = await _context.Classes.Where(x => x.IdClass != cl.IdClass).FirstOrDefaultAsync(x => x.NameClass == cl.NameClass);
                if (nameUnique != null)
                {
                    ModelState.AddModelError("", "Name already exists");
                    return View(cl);
                }
                _context.Add(cl);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Added";
                return RedirectToAction("Index");
            }
            return View(cl);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            Class cl = await _context.Classes.FirstOrDefaultAsync(x => x.IdClass == id);
            if (cl == null)
            {
                return NotFound();
            }
            ViewBag.IdTeacher = new SelectList(_context.Teachers.OrderBy(x => x.IdTeacher), "IdTeacher", "NameTeacher");
            return View(cl);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Class cl)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            if (ModelState.IsValid)
            {
                var nameUnique = await _context.Classes.Where(x => x.IdClass != cl.IdClass).FirstOrDefaultAsync(x => x.NameClass == cl.NameClass);
                if (nameUnique != null)
                {
                    ModelState.AddModelError("", "Name already exists");
                    return View(cl);
                }
                _context.Update(cl);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Class edited";
                return RedirectToAction("Edit", new { id = cl.IdClass });
            }
            return View(cl);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            Class cl = await _context.Classes.FindAsync(id);
            if (cl == null)
            {
                TempData["Error"] = "Error delete";
            }
            else
            {
                _context.Classes.Remove(cl);
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
