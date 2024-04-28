using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using DoAn.Filters;

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        [MyAuthenFilter]
        // GET: Cart
        //[MyAuthenFilter]
        public ActionResult Index()
        {
            WebDBContext db = new WebDBContext();
            List<Cart> carts = db.Carts.Include(c => c.Product).ToList();
            return View(carts);
        }
        public ActionResult Add(int id = 0)
        {
            if (id > 0)
            {
                WebDBContext db = new WebDBContext();
                Cart cartItem = db.Carts.Where(c => c.ProductID == id).FirstOrDefault();
                if (cartItem != null)
                    cartItem.Quantity += 1;
                else
                {
                    Cart cart = new Cart();
                    cart.ProductID = id;
                    cart.Quantity = 1;
                    db.Carts.Add(cart);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult UpdateQuantity(int quan = 0, int proid = 0)
        {
            WebDBContext db = new WebDBContext();
            if (quan > 0)
            {
                Cart cartItem = db.Carts.Where(c => c.ProductID == proid).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.Quantity = quan;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id = 0)
        {
            if (id > 0)
            {
                WebDBContext db = new WebDBContext();
                Cart cartItem = db.Carts.Where(c => c.ProductID == id).FirstOrDefault();
                if (cartItem != null)
                {
                    db.Carts.Remove(cartItem);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}