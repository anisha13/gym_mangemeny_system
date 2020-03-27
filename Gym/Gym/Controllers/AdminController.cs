using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.Models.Entity;
using Gym.Models.Manager;
using Gym.Models.DAL;
namespace Gym.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Index( )
        {


            return View(ManagerAdmin.GetAdmins());
        }


        public ActionResult Create()
        {
            return View();
        }
        public ActionResult ShowData()
        {
            List<admin> admins = new List<admin>();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                admins = dbe.admins.ToList();
            }
            return View(admins);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Admin", null);
            }
            return View(ManagerAdmin.DetailAdmin(id));
        }

        [HttpPost]
        public ActionResult Edit(AdminEntity detail)
        {
            ManagerAdmin.EditAdmin(detail);
            return RedirectToAction("Index", "Admin", null);
        }

        [HttpPost]
        public ActionResult SaveAdmin(AdminEntity detail)
        {
            ManagerAdmin.SaveAdmin(detail);
            return RedirectToAction("Index", "Admin", null);
        }


        public ActionResult DeleteAdmin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Admin", null);
            }
            ManagerAdmin.DelAdmin(id);
            return RedirectToAction("Index", "Admin", null);
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Admin", null);
            }
            return View(ManagerAdmin.DetailAdmin(id));
        }
    }
}