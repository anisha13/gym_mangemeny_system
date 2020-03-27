using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerAcccount
    {
        public static UserEntity ValidateAdminUser(UserEntity user)
        {
            UserEntity detail = new UserEntity();
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                admin admin = dbe.admins.Where(u => u.admin_username == user.username && u.admin_password == user.password).FirstOrDefault();
                if (admin != null)
                {
                    detail.id = admin.admin_id;
                    detail.username = admin.admin_username;
                    detail.fullname = admin.admin_fullname;
                    detail.Type = "admin";
                    detail.Roles = "Admin,Member";
                    return detail;
                }
            }
            return detail;
        }

        public static UserEntity ValidateMemberUser(UserEntity user)
        {
            UserEntity detail = new UserEntity();
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                customer custom = dbe.customers.Where(u => u.customer_username == user.username && u.customer_password == user.password).FirstOrDefault();
                if (custom != null)
                {
                    detail.id = custom.customer_id;
                    detail.username = custom.customer_username;
                    detail.fullname = custom.customer_fullname;
                    detail.Type = "member";
                    detail.Roles = "Member";
                    return detail;
                }
            }
            return detail;
        }
    }
}
        