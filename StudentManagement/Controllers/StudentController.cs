using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Models.Domain;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public StudentController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await mvcDbContext.Student.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            if (ModelState.IsValid)
            {


                var student = new Student()
                {
                    StudentId = addStudentRequest.StudentId,
                    StudentName = addStudentRequest.StudentName,
                    Dob = addStudentRequest.Dob,
                    Gender = addStudentRequest.Gender,
                    Email = addStudentRequest.Email,
                    PhoneNumber = addStudentRequest.PhoneNumber,
                    Score = addStudentRequest.Score,
                    ClassID = addStudentRequest.ClassID,
                };
                await mvcDbContext.Student.AddAsync(student);
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field can't be submit";
                return View(addStudentRequest);
            }

        }

        [HttpGet]
        public async Task<IActionResult> View(int StudentId)
        {
            var student = await mvcDbContext.Student.FirstOrDefaultAsync(x => x.StudentId == StudentId);
            if (student != null)
            {
                var viewModel = new UpdateStudentViewModel()
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    Dob = student.Dob,
                    Gender = student.Gender,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    Score = student.Score,
                    ClassID = student.ClassID,
                };

                return await Task.Run(() => View(viewModel));

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStudentViewModel model)
        {
            var student = await mvcDbContext.Student.FindAsync(model.StudentId);

            if (student != null)
            {
                mvcDbContext.Student.Remove(student);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateStudentViewModel model)
        {
            var student = await mvcDbContext.Student.FindAsync(model.StudentId);
            if (student != null)
            {
                student.StudentName = model.StudentName;
                student.Dob = model.Dob;
                student.Gender = model.Gender;
                student.Email = model.Email;
                student.PhoneNumber = model.PhoneNumber;
                student.Score = model.Score;
                student.ClassID = model.ClassID;

                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}

