using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.TeacherArea.Controllers
{
    [Area("TeacherArea")]
    public class HomeController : Controller
    {
        private readonly ManagerSchoolContext _context;

        public HomeController(ManagerSchoolContext context)
        {
            _context = context;
        }

        // GET: TeacherArea/Teachers
        public async Task<IActionResult> Index()
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == 3);
            return View(teacher);
        }

        // GET: TeacherArea/Teachers/Edit/5
        public async Task<IActionResult> Edit()
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == 3);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Teacher edited";
                return RedirectToAction("Edit", new { id = teacher.IdTeacher });
            }
            return View(teacher);
        }

        public async Task<IActionResult> ClassList()
        {
            IQueryable<Class> classes = from cl in _context.Classes where cl.IdTeacher == 3 select cl;
            List<Class> classList = await classes.ToListAsync();

            return View(classList);
        }

        public async Task<IActionResult> ClassDetail(string id)
        {
            int idd = 3;
            IQueryable<Student> students = from student in _context.Students where student.IdClass == idd select student;
            List<Student> studentList = await students.ToListAsync();
            //return students.Count() == 0 ? NotFound() : (IActionResult)View(students);
            return View(studentList);
        }
    }
}
