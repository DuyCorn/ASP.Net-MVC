using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            WebDBContext db = new WebDBContext();
            List<Product> cheapestProducts = db.Products.OrderBy(p => p.Price).Take(5).ToList();
            ViewBag.OutOfStock = db.Products.Where(row => row.Status == "Out Of Stock").ToList();

            return View(cheapestProducts);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Error404() 
        {
            return View();
        }
    }
}