using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagement.Controllers
{
    public class ClassController : Controller
    {
        private readonly SchoolManagementContext _context;
        public ClassController(SchoolManagementContext context)
        {
            _context = context;
        }
        public IActionResult Show()
        {
            var ClassData = _context.classInfos.FromSqlRaw($"SELECT * FROM dbo.classInfos").ToList();
            ViewBag.ClassData = ClassData;
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
            var ClassData = _context.classInfos.FromSqlRaw($"SELECT * FROM dbo.classInfos WHERE ClassId = '{search}'").ToList();
            if (ClassData == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.ClassData = ClassData;
                return View("Show");
            }
        }
        public async Task<IActionResult> Save(int ClassId, string ClassName, int ClassQuantity, int ClassTeacherId)
        {
            ClassInfo classs = new ClassInfo();
            if (ModelState.IsValid)
            {
                if (ClassName == null || ClassQuantity == null || ClassTeacherId == null || ClassId == null)
                {
                    return NotFound();
                }

                classs.ClassId = ClassId;
                classs.ClassName = ClassName;
                classs.ClassQuantity = ClassQuantity;
                classs.TeacherId = ClassTeacherId;
                _context.Add(classs);
                await _context.SaveChangesAsync();
            }

            ViewBag.ClassId = ClassId;
            ViewBag.ClassName = ClassName;
            ViewBag.ClassQuantity = ClassQuantity;
            ViewBag.ClassTeacherId = ClassTeacherId;
            return View("Add");
        }

        public IActionResult Search(string search)
        {
            var ClassData = _context.classInfos.FromSqlRaw($"SELECT * FROM dbo.classInfos WHERE ClassId = '{search}'").FirstOrDefault();
            if (ClassData == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.ClassId = ClassData.ClassId;
                ViewBag.ClassName = ClassData.ClassName;
                ViewBag.ClassQuantity = ClassData.ClassQuantity;
                ViewBag.ClassTeacherId = ClassData.TeacherId;
                return View("Edit");
            }
        }
       
    } 
}
