using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private MVCAppDatabaseEntities db = new MVCAppDatabaseEntities();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UserModel User)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Invalid Login Details";
                return View();
            }

            var user = from s in db.Users
                       join y in db.Roles
                       on s.RoleId equals y.id
                       where s.Name == User.Name && s.password == User.password
                       select new { id = s.id, Name = s.Name, RoleId = s.RoleId, RoleName = y.Name };

            if (user == null)
            {
                return View();
            }
            if (user.Count() > 0)
            {
                if (user.SingleOrDefault().RoleName == "Admin")
                {
                    ViewBag.Message = "";
                    FormsAuthentication.SetAuthCookie(User.Name, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.SingleOrDefault().Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.SingleOrDefault().RoleName);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Message = "Invalid Login Details";
            return View();
        }
    }
}