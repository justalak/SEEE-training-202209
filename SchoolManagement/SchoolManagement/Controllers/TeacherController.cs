using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.Enum;
using SchoolManagement.Models;
using System.Threading.Tasks;
using SchoolManagement.Data;
using System.Linq;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolManagementContext _context;
        public TeacherController(SchoolManagementContext context)
        {
            _context = context;
        }
        public IActionResult Show()
        {
            var TeacherData = _context.teacherInfos.FromSqlRaw("SELECT * FROM dbo.teacherInfos").ToList();
            ViewBag.TeacherData = TeacherData;
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult SearchShow(string search)
        {
            var TeacherData = _context.teacherInfos.FromSqlRaw($"SELECT * FROM dbo.teacherInfos WHERE TeacherId = '{search}'").ToList();
            if (TeacherData == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.StudentData = TeacherData;
                return View("Show");
            }
        }
        public async Task<IActionResult> Save(int TeacherId, string TeacherName, StudentGender TeacherGender, string TeacherEmail, string TeacherPhoneNumber)
        {
            TeacherInfo teachers = new TeacherInfo();
            if (ModelState.IsValid)
            {
                if (TeacherId == null || TeacherName == null || TeacherGender == null || TeacherEmail == null || TeacherPhoneNumber == null)
                {
                    return NotFound();
                }

                teachers.TeacherId = TeacherId;
                teachers.TeacherName = TeacherName;
                teachers.TeacherGender = TeacherGender;
                teachers.TeacherEmail = TeacherEmail;
                teachers.TeacherPhoneNumber = TeacherPhoneNumber;
                

                _context.Add(teachers);
                await _context.SaveChangesAsync();
            }

            ViewBag.TeacherId = TeacherId;
            ViewBag.TeacherName = TeacherName;
            ViewBag.TeacherGender = TeacherGender;
            ViewBag.TeacherEmail = TeacherEmail;
            ViewBag.TeacherPhoneNumber = TeacherPhoneNumber;
            return View("Add");
        }

        public IActionResult Search(string search)
        {
            var TeacherData = _context.teacherInfos.FromSqlRaw($"SELECT * FROM dbo.teacherInfos WHERE TeacherId = '{search}'").FirstOrDefault();
            if (TeacherData == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.TeacherId = TeacherData.TeacherId;
                ViewBag.TeacherName = TeacherData.TeacherName;
                ViewBag.TeacherGender = TeacherData.TeacherGender;
                ViewBag.TeacherEmail = TeacherData.TeacherEmail;
                ViewBag.TeacherPhoneNumber = TeacherData.TeacherPhoneNumber;
                return View("Edit");
            }
        }
    }
}
