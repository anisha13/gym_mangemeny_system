using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gym.Models.Entity;
using Gym.Models.Manager;
namespace Gym.Controllers
{
    public class AcccountController : Controller
    {
        // GET: Acccount
        public ActionResult Index()
        {
            return View();
        }

    

       [HttpPost]
        public ActionResult Index(UserEntity detail)
        {
            UserEntity entity = new UserEntity();
            if (detail.Type == "Admin")
            {
                entity = ManagerAcccount.ValidateAdminUser(detail);

                if (!string.IsNullOrEmpty(entity.id))
                {
                    FormsAuthentication.SetAuthCookie(entity.id, false);

                    var authTicket = new FormsAuthenticationTicket(1, entity.id, DateTime.Now, DateTime.Now.AddMinutes(120), false, entity.Roles);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Home");
                }
            }
            else if (detail.Type == "Member")
            {
                entity = ManagerAcccount.ValidateMemberUser(detail);

                if (!string.IsNullOrEmpty(entity.id))
                {
                    FormsAuthentication.SetAuthCookie(entity.id, false);

                    var authTicket = new FormsAuthenticationTicket(1, entity.id, DateTime.Now, DateTime.Now.AddMinutes(120), false, entity.Roles);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                   
                    return RedirectToAction("Index", "Home");
                }
            }
           

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(detail);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}