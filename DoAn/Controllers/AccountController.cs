using DoAn.Identity;
using DoAn.ViewModel;
using DoAn.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DoAn.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDBContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);

                // Kiểm tra xem Username đã tồn tại hay chưa
                if (userManager.Users.Any(u => u.UserName == register.Username))
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                    return View(register);
                }

                // Kiểm tra xem Email đã tồn tại hay chưa
                if (userManager.Users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "Email đã được sử dụng.");
                    return View(register);
                }

                var passwdHash = Crypto.HashPassword(register.Password);
                var user = new AppUser()
                {
                    Email = register.Email,
                    UserName = register.Username,
                    PasswordHash = passwdHash,
                    Birthday = register.DateOfBirth,
                    Address = register.Address,
                    PhoneNumber = register.Mobile
                };

                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    this.LoginUser(userManager, user);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Thông tin đăng kí không hợp lệ");
                return View(register);
            }
        }
        [NonAction]
        public void LoginUser(AppUserManager userManager, AppUser user)
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM logvm)
        {
            var appDbContext = new AppDBContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(logvm.Username, logvm.Password);
            if (user != null)
            {
                this.LoginUser(userManager, user);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Thông tin đăng nhập không hợp lệ");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}