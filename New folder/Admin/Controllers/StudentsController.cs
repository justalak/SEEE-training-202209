using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Infrastructure;
using MySchool.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsController : Controller
    {
        private readonly ManagerStudentContext _context;
        public StudentsController(ManagerStudentContext context)
        {
            _context = context;
        }
        // GET admin/students
        public async Task<IActionResult> Index()
        {
            IQueryable<Student> students = from st in _context.Students select st;
            List<Student> studentsList = await students.ToListAsync();
            return View(studentsList);
        }
        // GET admin/students/details/id
        public async Task<IActionResult> Details(int id)
        {
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // GET admin/students/create
        public IActionResult Create() => View();
        // POST admin/students/create
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
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
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // POST admin/students/create
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Edited";
                return RedirectToAction("Edit", student.IdStudent);
            }
            return View(student);
        }
        // GET admin/students/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                TempData["Error"] = "Error delete";
            }
            else
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
