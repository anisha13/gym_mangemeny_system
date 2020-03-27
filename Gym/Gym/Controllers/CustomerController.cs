using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Gym.Models.Entity;
using Gym.Models.Manager;
using Gym.Models.DAL;
using System.Security;
namespace Gym.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        public ActionResult Index()
        {


            return View(ManagerCustomer.GetCustomers());
        }


        public ActionResult Create()
        {
            ViewBag.trainerList = ManagerTrainer.GetTrainers().ToList();
            ViewBag.planList = ManagerPlan.Getplans().ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerEntity entity)
        {

            return Content(entity.customer_id);


        }
        public ActionResult ShowData()
        {
            List<customer> customers = new List<customer>();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                customers = dbe.customers.ToList();
            }
            return View(customers);
        }

        public ActionResult Edit(string id)
        {
            ViewBag.trainerList = ManagerTrainer.GetTrainers().ToList();
            ViewBag.planList = ManagerPlan.Getplans().ToList();

            if (string.IsNullOrEmpty(id))
            {
                
                return RedirectToAction("Index", "Customer", null);
            }
            return View(ManagerCustomer.DetailCustomer(id));
        }

        [HttpPost]
        public ActionResult Edit(CustomerEntity detail)
        {
            ManagerCustomer.EditCustomer(detail);
            return RedirectToAction("Index", "Customer", null);
        }

        [HttpPost]
        public ActionResult SaveCustomer(CustomerEntity entity)
        {
            string fileName = Path.GetFileNameWithoutExtension(entity.PhotoFile.FileName);
            string extension = Path.GetExtension(entity.PhotoFile.FileName);
            string newFilename = Guid.NewGuid().ToString();
            newFilename = newFilename + extension;
            string filePath = "~/Uploads//customer//";
            entity.customer_photo = newFilename;
            filePath = Server.MapPath(filePath + newFilename);
            entity.PhotoFile.SaveAs(filePath);
            ManagerCustomer.SaveCustomer(entity);
            return RedirectToAction("Index", "Customer", null);


        }


        public ActionResult DeleteCustomer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Customer", null);
            }
            ManagerCustomer.DelCustomer(id);
            return RedirectToAction("Index", "Customer", null);
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Customer", null);
            }
            CustomerEntity detail = ManagerCustomer.DetailCustomer(id);
            string filePath = "~/Uploads//customer//";
            detail.customer_photo = Path.Combine(filePath + detail.customer_photo);

            return View(detail);
        }
        public ActionResult DetailsNull()
        {
            string Name=HttpContext.User.Identity.Name;
            CustomerEntity detail = ManagerCustomer.DetailCustomer(Name);
            string filePath = "~/Uploads//customer//";
            detail.customer_photo = Path.Combine(filePath + detail.customer_photo);

            return View(detail);
        }
    }
}