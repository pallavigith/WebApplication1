using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_App.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL Context = new ProductDAL();
        public IActionResult List()
        {
            ViewBag.ProductList = Context.GetAllProducts();
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
            Product p = new Product();
            p.Name = form["Name"];
            p.Price = Convert.ToDecimal(form["Price"]);
            int res = Context.Save(p);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = Context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Id = prod.Id;
            return View();


        }
        [HttpPost]
        public IActionResult Edit(IFormCollection Form)
        {
            Product prod = new Product();
            prod.Name = Form["Name"];
            prod.Price = Convert.ToDecimal(Form["Price"]);
            prod.Id = Convert.ToInt32(Form["id"]);
            int res = Context.Update(prod);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product prod = Context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Id = prod.Id;
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
