using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.Enum;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly SchoolManagementContext _context;
        public StudentController(SchoolManagementContext context)
        {
            _context = context;
        }
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        public IActionResult Show()
        {
            var StudentData = _context.studentInfos.FromSqlRaw($"SELECT * FROM dbo.studentInfos").ToList();
            ViewBag.ClassData = StudentData;
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
            var StudentData = _context.studentInfos.FromSqlRaw($"SELECT * FROM dbo.studentInfos WHERE StudentId = '{search}'").ToList();
            if (StudentData == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.StudentData = StudentData;
                return View("Show");
            }
        }
        public async Task<IActionResult> Save(int StudentId, string StudentName, StudentGender StudentGender, string StudentEmail, string StudentPhoneNumber, float StudentScore, int StudentClassId)
        {
            StudentInfo students = new StudentInfo();
            if (ModelState.IsValid)
            {
                if (StudentId == null || StudentName == null || StudentGender == null || StudentEmail == null || StudentPhoneNumber == null || StudentScore == null || StudentClassId == null)
                {
                    return NotFound();
                }

                students.StudentId = StudentId;
                students.StudentName = StudentName;
                students.StudentGender = StudentGender;
                students.StudentEmail = StudentEmail;
                students.StudentPhoneNumber = StudentPhoneNumber;
                students.StudentScore = StudentScore;
                students.ClassId = StudentClassId;
                
                _context.Add(students);
                await _context.SaveChangesAsync();
            }

            ViewBag.StudentId = StudentId;
            ViewBag.StudentName = StudentName;
            ViewBag.StudentGender = StudentGender;
            ViewBag.StudentEmail = StudentEmail;
            ViewBag.StudentPhoneNumber = StudentPhoneNumber;
            ViewBag.StudentScore = StudentScore;
            ViewBag.StudentClassID = StudentClassId;
            return View("Add");
        }

        public IActionResult Search(string search)
        {
            var StudentData = _context.studentInfos.FromSqlRaw($"SELECT * FROM dbo.studentInfos WHERE ClassId = '{search}'").FirstOrDefault();
            if (StudentData == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.StudentId = StudentData.StudentId;
                ViewBag.StudentName = StudentData.StudentName;  
                ViewBag.StudentGender = StudentData.StudentGender;  
                ViewBag.StudentEmail = StudentData.StudentEmail;
                ViewBag.StudentPhoneNumber = StudentData.StudentPhoneNumber;
                ViewBag.StudentScore = StudentData.StudentScore;
                ViewBag.ClassId = StudentData.ClassId;
                return View("Edit");
            }
        }
    }
}
