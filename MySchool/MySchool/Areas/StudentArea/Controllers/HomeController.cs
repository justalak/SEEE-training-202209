using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using Newtonsoft.Json;
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

        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(Student student)
        {
            var check = _context.Students.Where(x => x.Email == student.Email && x.Password == student.Password);
            if (check.Any())
            {
                // Add session
                HttpContext.Session.SetString("StudentSession", JsonConvert.SerializeObject(check.FirstOrDefault()));
                HttpContext.Session.SetString("Role", "Student");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public async Task<IActionResult> Index()
        {
            //Student student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);
            //return View(student);

            if (CheckSession())
            {
                var check = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("StudentSession"));
                Student student = check;
                return View(student);
            }
            return View("Login");
        }
        public async Task<IActionResult> ClassDetail()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            var check = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("StudentSession"));
            Student st = check;
            IQueryable<Student> studentClass = from student in _context.Students where student.IdClass == st.IdClass select student;
            List<Student> studentsList = await studentClass.ToListAsync();
            Class cl = await _context.Classes.FirstOrDefaultAsync(x => x.IdClass == st.IdClass);
            Teacher tc = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == cl.IdTeacher);

            ViewBag.Students = studentsList;
            ViewBag.Teacher = tc;
            ViewBag.cl = cl;

            return View();
        }
        public async Task<IActionResult> Edit()
        {
            if (!CheckSession())
            {
                return View("../Home/Login");
            }
            var check = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("StudentSession"));
            Student student = check;
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
                    return View(student);
                }
                _context.Update(student);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Student edited";
                return RedirectToAction("Edit", new { id = student.IdStudent });
            }
            return View(student);
        }
        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("Role") == "Student")
            {
                return true;
            }
            return false;
        }
    }
}
