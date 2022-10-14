using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {
        static IList<Teacher> TeacherList = new List<Teacher>
        {
            new Teacher {Id="1", Name= "Simpson"},
            new Teacher {Id="2", Name= "Margarret"},
            new Teacher {Id="3", Name= "Mathi"}
        };
        // GET: HomeController3
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchTeacher = TeacherList.Where(s => s.Id == searchString);
                return View(searchTeacher);
            }
            return View(TeacherList.OrderBy(s => s.Id));
        }

        // GET: HomeController3/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController3/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher object_create)
        {
            var teacher_create = TeacherList.FirstOrDefault(s => s.Id == object_create.Id);
            TeacherList.Add(teacher_create);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController3/Edit/5
        public ActionResult Edit(string id)
        {
            var edit = TeacherList.Where(s => s.Id == id).FirstOrDefault();
            return View();
        }

        // POST: HomeController3/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher object_edit)
        {
            var teacher_edit = TeacherList.Where((s) => s.Id == object_edit.Id).FirstOrDefault();
            TeacherList.Remove(teacher_edit);
            TeacherList.Add(object_edit);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController3/Delete/5
        public ActionResult Delete(string id)
        {
            var delete = TeacherList.Where(s => s.Id == id).FirstOrDefault();
            return View(delete);
        }

        // POST: HomeController3/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher object_delete)
        {
            var teacher_edit = TeacherList.Where((s) => s.Id == object_delete.Id).FirstOrDefault();
            TeacherList.Remove(teacher_edit);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
