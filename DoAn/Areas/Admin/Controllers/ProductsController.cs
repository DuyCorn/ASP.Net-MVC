using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index(string search = "", int page = 1)
        {
            WebDBContext db = new WebDBContext();

            //Search
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;

            //Paging
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();


            return View(products);
        }
        public ActionResult Create()
        {
            WebDBContext db = new WebDBContext();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                WebDBContext db = new WebDBContext();

                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    product.Image = "";
                    db.Products.Add(product);
                    db.SaveChanges();

                    Product pro = db.Products.ToList().Last();

                    var fileName = pro.ProductID.ToString() + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);

                    pro.Image = fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    product.Image = "";
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                WebDBContext db = new WebDBContext();
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }
        }
        public ActionResult Detail(int id)
        {
            WebDBContext db = new WebDBContext();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
        public ActionResult Edit(int id)
        {
            WebDBContext db = new WebDBContext();
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            WebDBContext db = new WebDBContext();
            Product product = db.Products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();
            product.ProductName = pro.ProductName;
            product.Price = pro.Price;
            product.Description = pro.Description;
            product.Status = pro.Status;
            product.CategoryID = pro.CategoryID;
            product.BrandID = pro.BrandID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            WebDBContext db = new WebDBContext();
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            WebDBContext db = new WebDBContext();
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}