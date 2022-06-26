using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_App.Controllers
{
    public class EmployeeController : Controller
    {
        CourseDAL Context = new CourseDAL();
       

        public IActionResult List()
        {
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
            Employee E = new Employee();


            E.Name = form["Name"];
            E.Salary = Convert.ToDecimal(form["Salary"]);
            int res = Context.Save(E);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee E = Context.GetEmployeeById(id);
            ViewBag.Name = E.Name;
            ViewBag.Price = E.Salary;
            ViewBag.Id = E.Id;
            return View();


        }
        [HttpPost]
        public IActionResult Edit(IFormCollection Form)
        {
            Employee E = new Employee();

            E.Name = Form["Name"];
            E.Salary = Convert.ToDecimal(Form["Salary"]);
            E.Id = Convert.ToInt32(Form["id"]);
            int res = Context.Update(E);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee E= Context.GetEmployeeById(id);
            ViewBag.Name = E.Name;
            ViewBag.Salary= E.Salary;
            ViewBag.Id = E.Id;
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

    

