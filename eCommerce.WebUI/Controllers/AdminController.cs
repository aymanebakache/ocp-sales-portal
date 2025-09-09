using eCommerce.Contracts.Repositories;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; // Added for .Include()

namespace eCommerce.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Category> categories;
        
        public AdminController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Category> categories)
        {
            this.customers = customers;
            this.products = products;
            this.categories = categories;
        }
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            var model = products.GetAll()
                .Include(p => p.Category)  // Chargement eager des catégories
                .OrderBy(p => p.Description)
                .ToList();  // Exécution immédiate de la requête
            return View(model);
        }

        public ActionResult CreateProduct()
        {
            var model = new Product();
            ViewBag.CategoryId = new SelectList(categories.GetAll().Where(c => c.IsActive), "CategoryId", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.IsActive = true;
            products.Insert(product);
            products.Commit();
                TempData["Message"] = "Produit créé avec succès !";
            return RedirectToAction("ProductList");
            }
            
            ViewBag.CategoryId = new SelectList(categories.GetAll().Where(c => c.IsActive), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult EditProduct(int id)
        {
            Product product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CategoryId = new SelectList(categories.GetAll().Where(c => c.IsActive), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }
        
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
        {
            products.Update(product);
            products.Commit();
                TempData["Message"] = "Produit modifié avec succès !";
                return RedirectToAction("ProductList");
            }
            
            ViewBag.CategoryId = new SelectList(categories.GetAll().Where(c => c.IsActive), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            Product product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = products.GetById(id);
            if (product != null)
            {
                products.Delete(product);
                products.Commit();
                TempData["Message"] = "Produit supprimé avec succès !";
            }
            return RedirectToAction("ProductList");
        }
    }
}