//using Grocery2Go.Models;
//using Grocery2Go.Models.Views;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Grocery2Go.Controllers
//{
//    public class GroceriesController : Controller
//    {
//        private ApplicationDbContext _db = new ApplicationDbContext();

//        // GET: Groceries
//        public ActionResult Index()
//        {
//            var vm = new ProductsViewModel
//            {
//                Products = _db.Products.ToList()
//            };

//            return View(vm);
//        }
//        public ActionResult AddtoCart(int productId)
//        {
//            ShoppingCart userCart = new ShoppingCart()
//            {
//                UserId = _db.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault().Id,



//            };
//            _db.ShoppingCarts.Add(userCart);
//            _db.SaveChanges();
//            ShoppingCartItem sCI = new ShoppingCartItem()
//            {
//                ShoppingCartId = userCart.ShoppingCartId,
//                /* Product = _db.Products.Where(m => m.ProductId == id).FirstOrDefault()*/
//                ProductId = productId,
//                Quantity = 1
//            };
//            _db.ShoppingCartItems.Add(sCI);
//            _db.SaveChanges();



//            RedirectToAction("Index");

//            return View();
//        }

//        // GET: Groceries/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Groceries/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Groceries/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Groceries/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Groceries/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Groceries/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Groceries/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
