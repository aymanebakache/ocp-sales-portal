using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eCommerce.DAL.Data;
using eCommerce.Model;
using System.Text;

namespace eCommerce.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Products
        public ActionResult Index(string category = null, string search = null, int page = 1)
        {
            var products = db.Products.Include(p => p.Category).Where(p => p.IsActive);
            
            // Filtrage par catégorie
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Name == category);
                ViewBag.CurrentCategory = CleanString(category);
            }
            
            // Recherche
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Description.Contains(search));
                ViewBag.SearchTerm = CleanString(search);
            }
            
            // Pagination
            int pageSize = 12;
            int totalProducts = products.Count();
            int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
            
            var pagedProducts = products
                .OrderBy(p => p.Category.DisplayOrder)
                .ThenBy(p => p.Description)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalProducts = totalProducts;
            
            // Catégories pour le filtre
            ViewBag.Categories = db.Categories.Where(c => c.IsActive).OrderBy(c => c.DisplayOrder).ToList();
            
            return View(pagedProducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // Méthode pour nettoyer les caractères spéciaux
        private string CleanString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
                
            try
            {
                // Essayer de corriger l'encodage si c'est un problème de double-encodage
                if (input.Contains("Ã©"))
                {
                    input = input.Replace("Ã©", "é");
                }
                if (input.Contains("Ã¨"))
                {
                    input = input.Replace("Ã¨", "è");
                }
                if (input.Contains("Ã "))
                {
                    input = input.Replace("Ã ", "à");
                }
                if (input.Contains("Ã"))
                {
                    input = input.Replace("Ã", "É");
                }
                
                return input;
            }
            catch
            {
                return input;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
} 