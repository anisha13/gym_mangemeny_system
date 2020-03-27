using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Gym.Models.Entity;
using Gym.Models.Manager;
using Gym.Models.DAL;
namespace Gym.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {

            return View(ManagerTrainer.GetTrainers());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TrainerEntity entity)
        {

            return Content(entity.trainer_id);


        }
        public ActionResult ShowData()
        {
            List<trainer> trainers = new List<trainer>();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                trainers = dbe.trainers.ToList();
            }
            return View(trainers);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Trainer", null);
            }
            return View(ManagerTrainer.DetailTrainer(id));
        }

        [HttpPost]
        public ActionResult Edit(TrainerEntity detail)
        {
            ManagerTrainer.EditTrainer(detail);
            return RedirectToAction("Index", "Trainer", null);
        }

        [HttpPost]
        public ActionResult SaveTrainer(TrainerEntity entity)
        {
            string fileName = Path.GetFileNameWithoutExtension(entity.PhotoFile.FileName);
            string extension = Path.GetExtension(entity.PhotoFile.FileName);
            string newFilename = Guid.NewGuid().ToString();
            newFilename = newFilename + extension;
            string filePath = "~/Uploads//trainer//";
            entity.trainer_photo = newFilename;
            filePath = Server.MapPath(filePath + newFilename);
            entity.PhotoFile.SaveAs(filePath);
            ManagerTrainer.SaveTrainer(entity);
            return RedirectToAction("Index", "Trainer", null);


        }


        public ActionResult DeleteTrainer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Trainer", null);
            }
            bool result = ManagerTrainer.DelTrainer(id);
            if (result == true)
            {
                return RedirectToAction("Index", "Trainer", null);
            }
            else
            {


                return Content("Error deleting Record,, Trainer found to training customer Please modify customer Record First");

            }
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Trainer", null);
            }
            TrainerEntity detail = ManagerTrainer.DetailTrainer(id);
            string filePath = "~/Uploads//trainer//";
            detail.trainer_photo = Path.Combine(filePath + detail.trainer_photo);

            return View(detail);
        }
    }
}