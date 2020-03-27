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
    public class MemberController : Controller
    {
        // GET: Acccount
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(MemberEntity detail)
        {
            MemberEntity entity = new MemberEntity();
            if (detail.Type == "Admin")
            {
                entity = ManagerMember.ValidateCustomerMember(detail);
            }
            else if (detail.Type == "User")
            {

            }
            if (!string.IsNullOrEmpty(entity.customer_id))
            {
                FormsAuthentication.SetAuthCookie(entity.customer_id, false);

                var authTicket = new FormsAuthenticationTicket(1, entity.customer_id, DateTime.Now, DateTime.Now.AddMinutes(120), false, entity.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
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