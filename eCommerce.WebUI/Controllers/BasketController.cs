using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eCommerce.DAL.Data;
using eCommerce.Model;

namespace eCommerce.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Basket
        public ActionResult Index()
        {
            // Récupérer le panier de l'utilisateur actuel
            var basket = GetOrCreateBasket();
            var basketItems = db.BasketItems
                .Include(bi => bi.Product)
                .Include(bi => bi.Product.Category)
                .Where(bi => bi.BasketId == basket.BasketId)
                .ToList();

            ViewBag.TotalAmount = basketItems.Sum(bi => bi.Quantity * bi.Product.Price);
            return View(basketItems);
        }

        // POST: Basket/AddToBasket
        [HttpPost]
        public ActionResult AddToBasket(int id, int quantity = 1)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var basket = GetOrCreateBasket();
            var existingItem = db.BasketItems
                .FirstOrDefault(bi => bi.BasketId == basket.BasketId && bi.ProductId == id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var basketItem = new BasketItem
                {
                    BasketId = basket.BasketId,
                    ProductId = id,
                    Quantity = quantity
                };
                db.BasketItems.Add(basketItem);
            }

            db.SaveChanges();
            TempData["SuccessMessage"] = "Produit ajouté au panier avec succès.";
            
            return RedirectToAction("Index");
        }

        // GET: Basket/AddToBasket/5
        [HttpGet]
        public ActionResult AddToBasket(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return AddToBasket(id.Value, 1);
        }

        // POST: Basket/UpdateQuantity
        [HttpPost]
        public ActionResult UpdateQuantity(int basketItemId, int quantity)
        {
            var basketItem = db.BasketItems.Find(basketItemId);
            if (basketItem == null)
            {
                return HttpNotFound();
            }

            if (quantity <= 0)
            {
                db.BasketItems.Remove(basketItem);
            }
            else
            {
                basketItem.Quantity = quantity;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Basket/RemoveItem
        [HttpPost]
        public ActionResult RemoveItem(int basketItemId)
        {
            var basketItem = db.BasketItems.Find(basketItemId);
            if (basketItem != null)
            {
                db.BasketItems.Remove(basketItem);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Article supprimé du panier.";
            }

            return RedirectToAction("Index");
        }

        // GET: Basket/Checkout
        public ActionResult Checkout()
        {
            var basket = GetOrCreateBasket();
            var basketItems = db.BasketItems
                .Include(bi => bi.Product)
                .Where(bi => bi.BasketId == basket.BasketId)
                .ToList();

            if (!basketItems.Any())
            {
                TempData["ErrorMessage"] = "Votre panier est vide.";
                return RedirectToAction("Index");
            }

            ViewBag.TotalAmount = basketItems.Sum(bi => bi.Quantity * bi.Product.Price);
            return View();
        }

        // POST: Basket/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                var basket = GetOrCreateBasket();
                var basketItems = db.BasketItems
                    .Include(bi => bi.Product)
                    .Where(bi => bi.BasketId == basket.BasketId)
                    .ToList();

                if (!basketItems.Any())
                {
                    TempData["ErrorMessage"] = "Votre panier est vide.";
                    return RedirectToAction("Index");
                }

                // Créer la commande
                var order = new Order
                {
                    CustomerId = 1, // ID du client par défaut pour OCP
                    OrderDate = DateTime.Now,
                    TotalAmount = basketItems.Sum(bi => bi.Quantity * bi.Product.Price),
                    Status = "En attente",
                    Department = model.Department,
                    InternalRequest = model.InternalRequest
                };

                db.Orders.Add(order);
                db.SaveChanges();

                // Créer les éléments de commande
                foreach (var basketItem in basketItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = basketItem.ProductId,
                        Quantity = basketItem.Quantity,
                        UnitPrice = basketItem.Product.Price
                    };
                    db.OrderItems.Add(orderItem);
                }

                // Vider le panier
                db.BasketItems.RemoveRange(basketItems);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Votre commande a été enregistrée avec succès.";
                return RedirectToAction("Confirmation", new { orderId = order.OrderId });
            }

            var b = GetOrCreateBasket();
            var items = db.BasketItems
                .Include(bi => bi.Product)
                .Where(bi => bi.BasketId == b.BasketId)
                .ToList();

            ViewBag.TotalAmount = items.Sum(bi => bi.Quantity * bi.Product.Price);
            return View(model);
        }

        // GET: Basket/Confirmation
        public ActionResult Confirmation(int orderId)
        {
            var order = db.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.OrderItems.Select(oi => oi.Product))
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        private Basket GetOrCreateBasket()
        {
            // Pour simplifier, on utilise un panier par session
            var sessionId = Session.SessionID;
            var basket = db.Baskets.FirstOrDefault(b => b.SessionId == sessionId);

            if (basket == null)
            {
                basket = new Basket
                {
                    SessionId = sessionId,
                    CreatedDate = DateTime.Now
                };
                db.Baskets.Add(basket);
                db.SaveChanges();
            }

            return basket;
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

    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le département/service est requis")]
        public string Department { get; set; }

        [Required(ErrorMessage = "L'adresse est requise")]
        public string Address { get; set; }

        public string InternalRequest { get; set; }
    }
} 