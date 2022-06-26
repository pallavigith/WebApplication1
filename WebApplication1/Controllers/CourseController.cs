using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_App.Controllers
{
    public class CourseController : Controller
    {
        CourseDAL Context = new CourseDAL();

        public IActionResult List()
        {
            ViewBag.CourseList = Context.GetAllCourse();

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Course c = new Course();           
                c.Name = form["Name"];
            c.Fees = Convert.ToDecimal(form["Fees"]);
            int res = Context.Save(c);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           Course c= Context.GetCourseById(id);
            ViewBag.Name = c.Name;
            ViewBag.Price = c.Fees;
            ViewBag.Id = c.Id;
            return View();


        }
        [HttpPost]
        public IActionResult Edit(IFormCollection Form)
        {
            Course c = new Course();
            c.Name = Form["Name"];
            c.Fees = Convert.ToDecimal(Form[ "fees"]);
            c.Id = Convert.ToInt32(Form["id"]);
            int res = Context.Update(c);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course c = Context.GetCourseById(id);
            ViewBag.Name = c.Name;
            ViewBag.Price = c.Fees;
            ViewBag.Id = c.Id;
            return View();

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = Context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }




    }
}

    

