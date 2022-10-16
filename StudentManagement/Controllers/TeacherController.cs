using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Migrations;
using StudentManagement.Models;
using StudentManagement.Models.Domain;

namespace StudentManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public TeacherController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var teachers = await mvcDbContext.Teacher.ToListAsync();
            return View(teachers);
        }

    }
}

