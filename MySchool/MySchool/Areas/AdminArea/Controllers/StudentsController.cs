using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class StudentsController : Controller
    {
        private readonly ManagerSchoolContext _context;
        public StudentsController(ManagerSchoolContext context)
        {
            _context = context;
        }
        // GET admin/students
        public async Task<IActionResult> Index()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            IQueryable<Student> students = from student in _context.Students select student;
            List<Student> studentsList = await students.ToListAsync();
            return View(studentsList);
        }
        // GET admin/students/create
        public IActionResult Create()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            ViewBag.IdClass = new SelectList(_context.Classes.OrderBy(x => x.IdClass), "IdClass", "NameClass");
            return View();
        }
        // POST admin/students/create
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            if (ModelState.IsValid)
            {
                if (student == null)
                {
                    ModelState.AddModelError("", "Error Add");
                    return View(student);
                }
                _context.Add(student);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Added";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        // GET admin/students/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.IdClass = new SelectList(_context.Classes.OrderBy(x => x.IdClass), "IdClass", "NameClass");
            return View(student);
        }
        // POST admin/students/create
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            if (ModelState.IsValid)
            {
                var emailUnique = await _context.Students.Where(x => x.IdStudent != student.IdStudent).FirstOrDefaultAsync(x => x.Email == student.Email);
                if (emailUnique != null)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View();
                }
                _context.Update(student);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Student edited";
                return RedirectToAction("Edit", new { id = student.IdStudent });
            }
            return View(student);
        }
        // GET admin/students/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            Student student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                TempData["Error"] = "Error delete";
            }
            else
            {
                _context.Students.Remove(student);
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
