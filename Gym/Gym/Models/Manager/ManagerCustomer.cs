

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerCustomer
    {
        public static void SaveCustomer(CustomerEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                customer customer = new DAL.customer();
                customer.customer_id = detail.customer_id;
                customer.customer_fullname = detail.customer_fullname;
                customer.customer_address = detail.customer_address;
                customer.customer_phone = detail.customer_phone;
                customer.customer_photo = detail.customer_photo;
                customer.customer_gender = detail.customer_gender;
                customer.customer_joindate = detail.customer_joindate;
                customer.trainer_id = detail.trainer_id;
                customer.plan_id = detail.plan_id;
                customer.customer_username = detail.customer_username;
                customer.customer_password = detail.customer_password;



                dbe.customers.Add(customer);
                dbe.SaveChanges();
            }
        }

        public static void EditCustomer(CustomerEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                customer customer = dbe.customers.Find(detail.customer_id);
                customer.customer_fullname = detail.customer_fullname;
                customer.customer_address = detail.customer_address;
                customer.customer_phone = detail.customer_phone;
                customer.customer_photo = detail.customer_photo;
                customer.customer_gender = detail.customer_gender;
                customer.customer_joindate = detail.customer_joindate;
                customer.trainer_id = detail.trainer_id;
                customer.plan_id = detail.plan_id;
                customer.customer_username = detail.customer_username;
                customer.customer_password = detail.customer_password;




                dbe.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                dbe.SaveChanges();
            }
        }
        public static List<CustomerEntity> GetCustomers()
        {
            List<CustomerEntity> customers = new List<Entity.CustomerEntity>();

            using (fitnessEntities dbe = new fitnessEntities())
            {
                CustomerEntity customerEntity;
                var customerList = dbe.customers.ToList();
                foreach (var customer in customerList)
                {
                    customerEntity = new Entity.CustomerEntity();
                    customerEntity.customer_id = customer.customer_id;
                    customerEntity.customer_fullname = customer.customer_fullname;
                    customerEntity.customer_address = customer.customer_address;
                    customerEntity.customer_phone = customer.customer_phone;
                    customerEntity.customer_photo = customer.customer_photo;
                    customerEntity.customer_gender = customer.customer_gender;
                    customerEntity.customer_joindate = customer.customer_joindate;
                    customerEntity.trainer_name = customer.trainer_id;
                    customerEntity.plan_name = customer.plan_id;
                    customerEntity.customer_username = customer.customer_username;
                    customerEntity.customer_password = customer.customer_password;






                    customers.Add(customerEntity);
                }
            }
            return customers;
        }


        public static void DelCustomer(string Id)
        {
            using (fitnessEntities dbe = new fitnessEntities())
            {
                customer customer = dbe.customers.Where(o => o.customer_id.Equals(Id)).SingleOrDefault();
                dbe.customers.Remove(customer);
                dbe.SaveChanges();
            }
        }

        public static CustomerEntity DetailCustomer(string Id)
        {

            CustomerEntity customerEntity = new Entity.CustomerEntity();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                customer customer = dbe.customers.Where(o => o.customer_id.Equals(Id)).SingleOrDefault();
                customerEntity.customer_id = customer.customer_id;
                customerEntity.customer_fullname = customer.customer_fullname;
                customerEntity.customer_address = customer.customer_address;
                customerEntity.customer_phone = customer.customer_phone;
                customerEntity.customer_photo = customer.customer_photo;
                customerEntity.customer_gender = customer.customer_gender;
                customerEntity.customer_joindate = customer.customer_joindate;
                customerEntity.trainer_id = customer.trainer_id;
                customerEntity.plan_id = customer.plan_id;
                customerEntity.customer_username = customer.customer_username;
                customerEntity.customer_password = customer.customer_password;




            }
            return customerEntity;
        }
    }
}