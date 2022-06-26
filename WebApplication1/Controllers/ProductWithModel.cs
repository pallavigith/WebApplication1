using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Core_App.Models;

namespace MVC_Core_App.Controllers
{
    public class ProductWithModel : Controller
    {
        ProductDAL db = new ProductDAL();

        // GET: ProductWithModel
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        // GET: ProductWithModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductWithModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductWithModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product  prod)
        {
            try
            {
                db.Save(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductWithModel/Edit/5
        public ActionResult Edit(int id)
        {
            Product prod = db.GetProductById(id);
            return View(prod);
        }

        // POST: ProductWithModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                db.Update(prod);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductWithModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductWithModel/Delete/5
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
