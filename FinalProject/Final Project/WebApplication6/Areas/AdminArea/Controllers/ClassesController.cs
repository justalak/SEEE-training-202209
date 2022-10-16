using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Infrastructure;
using WebApplication6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
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
            return View(await _context.Classes.OrderBy(x => x.IdClass).ToListAsync());
        }
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Class cl)
        {
            if (ModelState.IsValid)
            {
                if (cl == null)
                {
                    ModelState.AddModelError("", "Error Add");
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
    }
}
