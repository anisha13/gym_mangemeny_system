

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerTrainer
    {
        public static void SaveTrainer(TrainerEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                trainer trainer = new DAL.trainer();
                trainer.trainer_id = detail.trainer_id;
                trainer.trainer_name = detail.trainer_name;
                trainer.trainer_contact = detail.trainer_contact;
                trainer.trainer_address = detail.trainer_address;
                trainer.trainer_photo = detail.trainer_photo;


                dbe.trainers.Add(trainer);
                dbe.SaveChanges();
            }
        }

        public static void EditTrainer(TrainerEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                trainer trainer = dbe.trainers.Find(detail.trainer_id);
                trainer.trainer_name = detail.trainer_name;
                trainer.trainer_contact = detail.trainer_contact;
                trainer.trainer_address = detail.trainer_address;
            //    trainer.trainer_photo = detail.trainer_photo;



            //    dbe.Entry(trainer).State = System.Data.Entity.EntityState.Modified;
                dbe.SaveChanges();
            }
        }
        public static List<TrainerEntity> GetTrainers()
        {
            List<TrainerEntity> trainers = new List<Entity.TrainerEntity>();

            using (fitnessEntities dbe = new fitnessEntities())
            {
                TrainerEntity trainerEntity;
                var trainerList = dbe.trainers.ToList();
                foreach (var trainer in trainerList)
                {
                    trainerEntity = new Entity.TrainerEntity();
                    trainerEntity.trainer_id = trainer.trainer_id;
                    trainerEntity.trainer_name = trainer.trainer_name;
                    trainerEntity.trainer_contact = trainer.trainer_contact;
                    trainerEntity.trainer_address = trainer.trainer_address;
                    trainerEntity.trainer_photo = trainer.trainer_photo;






                    trainers.Add(trainerEntity);
                }
            }
            return trainers;
        }


        public static bool DelTrainer(string Id)
        {
            using (fitnessEntities dbe = new fitnessEntities())
            {
                var cst = dbe.customers.Where(o => o.trainer_id == Id).ToList();
                if (cst.Count == 0)
                {
                    trainer trainer = dbe.trainers.Where(o => o.trainer_id.Equals(Id)).SingleOrDefault();
                    dbe.trainers.Remove(trainer);
                    dbe.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static TrainerEntity DetailTrainer(string Id)
        {

            TrainerEntity trainerEntity = new Entity.TrainerEntity();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                trainer trainer = dbe.trainers.Where(o => o.trainer_id.Equals(Id)).SingleOrDefault();
                trainerEntity.trainer_id = trainer.trainer_id;
                trainerEntity.trainer_name = trainer.trainer_name;
                trainerEntity.trainer_contact = trainer.trainer_contact;
                trainerEntity.trainer_address = trainer.trainer_address;
                trainerEntity.trainer_photo = trainer.trainer_photo;



            }
            return trainerEntity;
        }
    }
}