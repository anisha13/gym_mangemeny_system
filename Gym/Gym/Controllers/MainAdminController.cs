using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [Authorize]
    public class MainAdminController : Controller
    {
        // GET: MainAdmin
        public ActionResult Index(string id)
        {
            //if(id.ToUpper()=="ADMIN")
            //{
            //    RedirectToAction("AdminLogin");
            //}
            return View();
        }
    }
}