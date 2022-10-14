using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        static IList<Student> StudentList = new List<Student>
        {
            new Student(){Id="1",Name="Peter Griffin",Gender="Male",Email="ptgrif@gmail.com",PhoneNumber="0926539812", Score= 3.0, ClassId="123456"},
            new Student(){Id="2",Name="Stewie Griffin",Gender="Male",Email="stgrif@gmail.com",PhoneNumber="0926539000", Score= 3.9, ClassId="123123"},
            new Student(){Id="3",Name="Lois Griffin",Gender="Female",Email="lsgrif@gmail.com",PhoneNumber="0926539001", Score= 3.5, ClassId="123111"}
        };
        // GET: HomeController2
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchStudent = StudentList.Where(s => s.Id == searchString);
                return View(searchStudent);
            }
            return View(StudentList.OrderBy(s => s.Id));
        }

        // GET: HomeController2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student create_student)
        {
            StudentList.Add(create_student);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController2/Edit/5
        public ActionResult Edit(string id)
        {
            var edit = StudentList.Where(s => s.Id == id).FirstOrDefault();
            return View();
        }

        // POST: HomeController2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student object_edit)
        {
            var student_edit = StudentList.Where(s => s.Id == object_edit.Id).FirstOrDefault();
            StudentList.Remove(student_edit);
            StudentList.Add(object_edit);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController2/Delete/5
        public ActionResult Delete(string id)
        {
            var delete = StudentList.Where(s => s.Id == id).FirstOrDefault();
            return View(delete);
        }

        // POST: HomeController2/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student object_delete)
        {
            var student_delete = StudentList.Where(s => s.Id == object_delete.Id).FirstOrDefault();
            StudentList.Remove(student_delete);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
