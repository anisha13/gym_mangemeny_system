using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Gym.Models.Entity;
using Gym.Models.Manager;
using Gym.Models.DAL;
namespace Gym.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {

            return View(ManagerEquipment.GetEquipments());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EquipmentEntity entity)
        {

            return Content(entity.equipment_id);


        }
        public ActionResult ShowData()
        {
            List<equipment> equipments = new List<equipment>();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                equipments = dbe.equipments.ToList();
            }
            return View(equipments);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Equipment", null);
            }
            return View(ManagerEquipment.DetailEquipment(id));
        }

        [HttpPost]
        public ActionResult Edit(EquipmentEntity detail)
        {
            ManagerEquipment.EditEquipment(detail);
            return RedirectToAction("Index", "Equipment", null);
        }

        [HttpPost]
        public ActionResult SaveEquipment(EquipmentEntity entity)
        {
            string fileName = Path.GetFileNameWithoutExtension(entity.PhotoFile.FileName);
            string extension = Path.GetExtension(entity.PhotoFile.FileName);
            string newFilename = Guid.NewGuid().ToString();
            newFilename = newFilename + extension;
            string filePath = "~/Uploads//equipment//";
            entity.equipment_photo = newFilename;
            filePath = Server.MapPath(filePath + newFilename);
            entity.PhotoFile.SaveAs(filePath);
            ManagerEquipment.SaveEquipment(entity);
            return RedirectToAction("Index", "Equipment", null);


        }


        public ActionResult DeleteEquipment(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Equipment", null);
            }
            ManagerEquipment.DelEquipment(id);
            return RedirectToAction("Index", "Equipment", null);
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Equipment", null);
            }
            EquipmentEntity detail = ManagerEquipment.DetailEquipment(id);
            string filePath = "~/Uploads//equipment//";
            detail.equipment_photo = Path.Combine(filePath + detail.equipment_photo);

            return View(detail);
        }
    }
}