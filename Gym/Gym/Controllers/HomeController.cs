//HomeController

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Roles ="Admin,Member")]
        public ActionResult Index()
        {
            
            return View();
        }
        [Authorize(Roles ="Member")]
       public ActionResult MemberIndex()
        {
            return View();
        }
        
    }
}