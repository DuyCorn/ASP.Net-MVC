using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using DoAn.Filters;

namespace DoAn.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            WebDBContext db = new WebDBContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}