
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerMember
    {
        public static MemberEntity ValidateCustomerMember(MemberEntity member)
{
    MemberEntity detail = new MemberEntity();
    using (fitnessEntities dbe = new DAL.fitnessEntities())
    {
        customer customer = dbe.customers.Where(m => m.customer_username == member.customer_username && m.customer_password == member.customer_password).FirstOrDefault();
        if (customer != null)
        {
            detail.customer_id = customer.customer_id;
            detail.customer_username = customer.customer_username;
            detail.customer_fullname = customer.customer_fullname;
            detail.Type = "user";
            detail.Roles = "Admin,User";
            return detail;
        }
    }
    return detail;
}
    }

        }
    