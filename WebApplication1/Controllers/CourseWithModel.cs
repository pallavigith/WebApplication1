using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_App.Controllers
{
    public class CourseWithModel : Controller
    {
        CourseDAL db = new CourseDAL();
        // GET: CourseWithController
        public ActionResult Index()
        {
            var model = db.GetAllCourse();
            return View(model);


          
        }

        // GET: CourseWithController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseWithController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseWithController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course c)
        {
            try
            {
                db.Save(c);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithController/Edit/5
        public ActionResult Edit(int id)
        {
            Course c = db.GetCourseById(id);
            return View(c);
            
        }

        // POST: CourseWithController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course c)
        {
            try
            {
                db.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseWithController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                db.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
