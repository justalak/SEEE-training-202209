using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.StudentArea.Controllers
{
    [Area("StudentArea")]
    public class HomeController : Controller
    {
        private readonly ManagerSchoolContext _context;
        public HomeController(ManagerSchoolContext context)
        {
            _context = context;
        }
        public int id = 1;

        public async Task<IActionResult> Index()
        {
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);
            return View(student);
        }
        public async Task<IActionResult> ClassDetail()
        {
            IQueryable<Student> studentClass = from student in _context.Students where student.IdClass == 1 select student;
            List<Student> studentsList = await studentClass.ToListAsync();
            Class cl = await _context.Classes.FirstOrDefaultAsync(x => x.IdClass == 1);
            Teacher tc = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == cl.IdTeacher);

            ViewBag.Students = studentsList;
            ViewBag.Teacher = tc;
            ViewBag.cl = cl;

            return View();
        }
        public async Task<IActionResult> Edit()
        {
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
            if (ModelState.IsValid)
            {
                var emailUnique = await _context.Students.Where(x => x.IdStudent != student.IdStudent).FirstOrDefaultAsync(x => x.Email == student.Email);
                if (emailUnique != null)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View(student);
                }
                _context.Update(student);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Student edited";
                return RedirectToAction("Edit", new { id = student.IdStudent });
            }
            return View(student);
        }
    }
}
