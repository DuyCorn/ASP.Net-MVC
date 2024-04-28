using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Identity;
using DoAn.Filters;

namespace DoAn.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            AppDBContext db = new AppDBContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
    }
}