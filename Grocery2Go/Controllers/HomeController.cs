using Grocery2Go.Models;
using Grocery2Go.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Grocery2Go.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Groceries
        public ActionResult Index()
        {
            var vm = new ProductsViewModel
            {
                Products = _db.Products.ToList(),

                ShoppingCartList = _db.Users.Where(m => m.UserName == User.Identity.Name).Include(m => m.ShoppingCart.ShoppingCartList).FirstOrDefault().ShoppingCart.ShoppingCartList

            };

            return View(vm);
        }

        [Authorize]
        public ActionResult ShoppingCart()
        {
            return View();
        }


        public ActionResult AddToCart(int productId)
        {
            
            var user = _db.Users.Where(m => m.UserName == User.Identity.Name).Include(m => m.ShoppingCart.ShoppingCartList).FirstOrDefault();


            user.ShoppingCart.ShoppingCartList.Add(new ShoppingCartItem
                {
                    ProductId = productId, 
                    Quantity = 1
                });

            //ShoppingCart userCart = new ShoppingCart();
            //if (userCart == null)
            //{
            //    userCart.UserId = _db.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault().Id;


            //}
            //else
            //{
            //    userCart = _db.ShoppingCarts.FirstOrDefault();
            //}
          
            _db.SaveChanges();



           return Redirect("Index");

            //return View();
        }

        // GET: Groceries/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Groceries/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Groceries/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Groceries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Groceries/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Groceries/Delete/5
        public ActionResult DeleteFromCart(int shoppingCartItemid)
        {
            var user = _db.Users.Where(m => m.UserName == User.Identity.Name).Include(m => m.ShoppingCart.ShoppingCartList).FirstOrDefault();
            var sCl = user.ShoppingCart.ShoppingCartList;
            var sC2 = sCl.Where(m => m.ShoppingCartItemId == shoppingCartItemid).FirstOrDefault();
            sCl.Remove(sC2);
            var dBI = _db.ShoppingCartItems.Where(m => m.ShoppingCartItemId == shoppingCartItemid).FirstOrDefault();
            _db.ShoppingCartItems.Remove(dBI);

            _db.SaveChanges();

            return Redirect("Index");

        }

        //// POST: Groceries/Delete/5
        //[HttpPost]
        //public ActionResult DeleteFromCart(int shoppingCartItemid, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
