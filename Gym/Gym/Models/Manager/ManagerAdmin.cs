

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerAdmin
    {
        public static void SaveAdmin(AdminEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                admin admin = new DAL.admin();
                admin.admin_id = detail.admin_id;
                admin.admin_fullname = detail.admin_fullname;
                admin.admin_username = detail.admin_username;
                admin.admin_password = detail.admin_password;

                dbe.admins.Add(admin);
                dbe.SaveChanges();
            }
        }

        public static void EditAdmin(AdminEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                admin admin = dbe.admins.Find(detail.admin_id);
                admin.admin_fullname = detail.admin_fullname;
                admin.admin_username = detail.admin_username;
                admin.admin_password = detail.admin_password;


                dbe.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                dbe.SaveChanges();
            }
        }
        public static List<AdminEntity> GetAdmins()
        {
            List<AdminEntity> admins = new List<Entity.AdminEntity>();

            using (fitnessEntities dbe = new fitnessEntities())
            {
                AdminEntity adminEntity;
                var adminList = dbe.admins.ToList();
                foreach (var admin in adminList)
                {
                    adminEntity = new Entity.AdminEntity();
                    adminEntity.admin_id = admin.admin_id;
                    adminEntity.admin_fullname = admin.admin_fullname;
                    adminEntity.admin_username = admin.admin_username;
                    adminEntity.admin_password = admin.admin_password;





                    admins.Add(adminEntity);
                }
            }
            return admins;
        }


        public static void DelAdmin(string Id)
        {
            using (fitnessEntities dbe = new fitnessEntities())
            {
                admin admin = dbe.admins.Where(o => o.admin_id.Equals(Id)).SingleOrDefault();
                dbe.admins.Remove(admin);
                dbe.SaveChanges();
            }
        }

        public static AdminEntity DetailAdmin(string Id)
        {

            AdminEntity adminEntity = new Entity.AdminEntity();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                admin admin = dbe.admins.Where(o => o.admin_id.Equals(Id)).SingleOrDefault();
                adminEntity.admin_id = admin.admin_id;
                adminEntity.admin_fullname = admin.admin_fullname;
                adminEntity.admin_username = admin.admin_username;
                adminEntity.admin_password = admin.admin_password;


            }
            return adminEntity;
        }
    }
}