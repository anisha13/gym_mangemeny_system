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
    public class planController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {

            return View(ManagerPlan.Getplans());
        }


        public ActionResult Create()
        {
            return View();
        }
        public ActionResult ShowData()
        {
            List<plan> plans = new List<plan>();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                plans = dbe.plans.ToList();
            }
            return View(plans);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "plan", null);
            }
            return View(ManagerPlan.Detailplan(id));
        }

        [HttpPost]
        public ActionResult Edit(PlanEntity detail)
        {
            ManagerPlan.EditPlan(detail);
            return RedirectToAction("Index", "plan", null);
        }

        [HttpPost]
        public ActionResult Saveplan(PlanEntity detail)
        {
            ManagerPlan.Saveplan(detail);
            return RedirectToAction("Index", "plan", null);
        }


        public ActionResult DeletePlan(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Plan", null);
            }
            bool result = ManagerPlan.Delplan(id);
            if (result == true)
            {
                return RedirectToAction("Index", "Plan", null);
            }
            else
            {


                return Content("Error deleting Record,, Plan found to planing customer Please modify customer Record First");

            }
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "plan", null);
            }
            return View(ManagerPlan.Detailplan(id));
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}