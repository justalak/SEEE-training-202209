using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClassController : Controller
    {
        
        static IList<Class> ClassList = new List<Class>
        {
            new Class() {Id="1", Name= "Biology", TeacherId="123123"},
            new Class() {Id="2", Name= "Science", TeacherId="123000"},
            new Class() {Id="3", Name= "Math", TeacherId="123001"}
        };
        // GET: HomeController1
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchClass = ClassList.Where(s => s.Id == searchString);
                return View(searchClass);
            }
            return View(ClassList.OrderBy(s => s.Id));
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class newClass)
        {
           
            ClassList.Add(newClass);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(string id )
        {
            var edit = ClassList.Where(s => s.Id == id).FirstOrDefault();
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Class object_edit)
        {
            var class_edit = ClassList.Where(s => s.Id == object_edit.Id).FirstOrDefault();
            ClassList.Remove(class_edit);
            ClassList.Add(object_edit);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(string id)
        {
            var delete = ClassList.Where(s => s.Id == id).FirstOrDefault();
            return View(delete);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Class object_delete)
        {
            var class_delete = ClassList.Where(s => s.Id == object_delete.Id).FirstOrDefault();
            ClassList.Remove(class_delete);
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
