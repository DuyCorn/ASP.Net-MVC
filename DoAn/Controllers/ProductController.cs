using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string search = "", int page = 1)
        {
            WebDBContext db = new WebDBContext();

            //Search
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;

            //Paging
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();


            return View(products);
        }
        public ActionResult Dung(int page = 1)
        {
            WebDBContext db = new WebDBContext();
            List<Product> products = db.Products.Where(row => row.Category.CategoryID == 1).ToList();
            //Paging
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(products);
        }
        public ActionResult Treo(int page = 1)
        {
            WebDBContext db = new WebDBContext();
            List<Product> products = db.Products.Where(row => row.Category.CategoryID == 2).ToList();

            //Paging
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(products);
        }
        public ActionResult Tran(int page = 1)
        {
            WebDBContext db = new WebDBContext();
            List<Product> products = db.Products.Where(row => row.Category.CategoryID == 3).ToList();
            //Paging
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(products);
        }
        public ActionResult Detail(int id)
        {
            WebDBContext db = new WebDBContext();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
    }
}