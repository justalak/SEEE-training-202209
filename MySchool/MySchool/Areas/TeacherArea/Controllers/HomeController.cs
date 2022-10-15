using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using Newtonsoft.Json;
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
        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(Teacher teacher)
        {
            var check = _context.Teachers.Where(x => x.Email == teacher.Email && x.Password == teacher.Password);
            if (check.Any())
            {
                // Add session
                HttpContext.Session.SetString("TeacherSession", JsonConvert.SerializeObject(check.FirstOrDefault()));
                HttpContext.Session.SetString("Role", "Teacher");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        // GET: TeacherArea/Teachers
        public async Task<IActionResult> Index()
        {
            if (CheckSession())
            {
                var check = JsonConvert.DeserializeObject<Teacher>(HttpContext.Session.GetString("TeacherSession"));
                Teacher teacher = check;
                return View(teacher);
            }
            return View("Login");
        }

        // GET: TeacherArea/Teachers/Edit/5
        public async Task<IActionResult> Edit()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            var check = JsonConvert.DeserializeObject<Teacher>(HttpContext.Session.GetString("TeacherSession"));
            Teacher teacher = check;

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
                return RedirectToAction("Edit");
            }
            return View(teacher);
        }

        public async Task<IActionResult> ClassList()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            var check = JsonConvert.DeserializeObject<Teacher>(HttpContext.Session.GetString("TeacherSession"));
            Teacher teacher = check;

            IQueryable<Class> classes = from cl in _context.Classes where cl.IdTeacher == teacher.IdTeacher select cl;
            List<Class> classList = await classes.ToListAsync();

            return View(classList);
        }

        public async Task<IActionResult> ClassDetail(int id)
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            IQueryable<Student> students = from student in _context.Students where student.IdClass == id select student;
            List<Student> studentList = await students.ToListAsync();
            return students.Count() == 0 ? NotFound() : (IActionResult)View(students);
        }
        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("Role") == "Teacher")
            {
                return true;
            }
            return false;
        }
    }
}
