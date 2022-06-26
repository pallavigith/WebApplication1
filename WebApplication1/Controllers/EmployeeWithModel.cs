using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Core_App.Models;


namespace MVC_Core_App.Controllers
{
    public class EmployeeWithModel : Controller
    {
        EmployeeDAL db = new EmployeeDAL();

        // GET: EmployeeWithModelController
        public ActionResult Index()
        {
            var model = db.GetAllEmployee();
            return View(model);

            
        }

        // GET: EmployeeWithModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee E)
        {
            try
            {
                db.Save(E);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee E = db.GetEmployeeById(id);
            return View(E);
            
        }

        // POST: EmployeeWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee E)
        {
            try
            {
                db.Update(E);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeWithModelController/Delete/5
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
