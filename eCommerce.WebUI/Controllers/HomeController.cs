using eCommerce.Contracts.Repositories;
using eCommerce.DAL.Data;
using eCommerce.DAL.Repositories;
using eCommerce.Model;
using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        
        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
        {
            this.customers = customers;
            this.products = products;
        }
        
        public ActionResult Index()
        {
            // Récupérer les produits actifs pour la vitrine
            var productList = products.GetAll()
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.ProductId)
                .Take(6)
                .ToList();
             
            return View(productList);
        }

        public ActionResult Details(int id)
        {
            var product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "À propos d'OCP Groupe";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactez-nous";
            return View();
        }
    }
}