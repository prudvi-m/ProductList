using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductList.Models;

namespace ProductList.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext context { get; set; }

        public ProductController(ProductContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categorys = context.Categorys.OrderBy(g => g.Name).ToList();
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categorys = context.Categorys.OrderBy(g => g.Name).ToList();
            var Product = context.Products.Find(id);
            return View(Product);
        }

        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            if (ModelState.IsValid)
            {
                if (Product.ProductId == 0) 
                    context.Products.Add(Product);
                else 
                    context.Products.Update(Product);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (Product.ProductId == 0) ? "Add": "Edit";
                ViewBag.Categorys = context.Categorys.OrderBy(g => g.Name).ToList();
                return View(Product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Product = context.Products.Find(id);
            return View(Product);
        }

        [HttpPost]
        public IActionResult Delete(Product Product)
        {
            context.Products.Remove(Product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}