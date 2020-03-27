

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerEquipment
    {
        public static void SaveEquipment(EquipmentEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                equipment equipment = new DAL.equipment();
                equipment.equipment_id = detail.equipment_id;
                equipment.equipment_name = detail.equipment_name;
                equipment.equipment_quantity = detail.equipment_quantity;
                equipment.equipment_cost = detail.equipment_cost;
                equipment.equipment_photo = detail.equipment_photo;


                dbe.equipments.Add(equipment);
                dbe.SaveChanges();
            }
        }

        public static void EditEquipment(EquipmentEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                equipment equipment = dbe.equipments.Find(detail.equipment_id);
                equipment.equipment_name = detail.equipment_name;
                equipment.equipment_quantity = detail.equipment_quantity;
                equipment.equipment_cost = detail.equipment_cost;
            //    equipment.equipment_photo = detail.equipment_photo;



            //    dbe.Entry(equipment).State = System.Data.Entity.EntityState.Modified;
                dbe.SaveChanges();
            }
        }
        public static List<EquipmentEntity> GetEquipments()
        {
            List<EquipmentEntity> equipments = new List<Entity.EquipmentEntity>();

            using (fitnessEntities dbe = new fitnessEntities())
            {
                EquipmentEntity equipmentEntity;
                var equipmentList = dbe.equipments.ToList();
                foreach (var equipment in equipmentList)
                {
                    equipmentEntity = new Entity.EquipmentEntity();
                    equipmentEntity.equipment_id = equipment.equipment_id;
                    equipmentEntity.equipment_name = equipment.equipment_name;
                    equipmentEntity.equipment_quantity = equipment.equipment_quantity;
                    equipmentEntity.equipment_cost = equipment.equipment_cost;
                    equipmentEntity.equipment_photo = equipment.equipment_photo;






                    equipments.Add(equipmentEntity);
                }
            }
            return equipments;
        }


        public static void DelEquipment(string Id)
        {
            using (fitnessEntities dbe = new fitnessEntities())
            {
                equipment equipment = dbe.equipments.Where(o => o.equipment_id.Equals(Id)).SingleOrDefault();
                dbe.equipments.Remove(equipment);
                dbe.SaveChanges();
            }
        }

        public static EquipmentEntity DetailEquipment(string Id)
        {

            EquipmentEntity equipmentEntity = new Entity.EquipmentEntity();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                equipment equipment = dbe.equipments.Where(o => o.equipment_id.Equals(Id)).SingleOrDefault();
                equipmentEntity.equipment_id = equipment.equipment_id;
                equipmentEntity.equipment_name = equipment.equipment_name;
                equipmentEntity.equipment_quantity = equipment.equipment_quantity;
                equipmentEntity.equipment_cost = equipment.equipment_cost;
                equipmentEntity.equipment_photo = equipment.equipment_photo;



            }
            return equipmentEntity;
        }
    }
}