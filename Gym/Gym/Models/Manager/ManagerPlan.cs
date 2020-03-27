

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.DAL;
using Gym.Models.Entity;
namespace Gym.Models.Manager
{
    public class ManagerPlan
    {
        public static void Saveplan(PlanEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                plan plan = new DAL.plan();
                plan.plan_id = detail.plan_id;
                plan.plan_name = detail.plan_name;
                plan.plan_cost = detail.plan_cost;
                plan.plan_period = detail.plan_period;


                dbe.plans.Add(plan);
                dbe.SaveChanges();
            }
        }

        public static void EditPlan(PlanEntity detail)
        {
            using (fitnessEntities dbe = new DAL.fitnessEntities())
            {
                plan plan = dbe.plans.Find(detail.plan_id);
                plan.plan_name = detail.plan_name;
                plan.plan_cost = detail.plan_cost;
                plan.plan_period = detail.plan_period;
                dbe.Entry(plan).State = System.Data.Entity.EntityState.Modified;
                dbe.SaveChanges();
            }
        }
        public static List<PlanEntity> Getplans()
        {
            List<PlanEntity> plans = new List<Entity.PlanEntity>();

            using (fitnessEntities dbe = new fitnessEntities())
            {
                PlanEntity planEntity;
                var planList = dbe.plans.ToList();
                foreach (var plan in planList)
                {
                    planEntity = new Entity.PlanEntity();
                    planEntity.plan_id = plan.plan_id;
                    planEntity.plan_name = plan.plan_name;
                    planEntity.plan_cost = plan.plan_cost;
                    planEntity.plan_period = plan.plan_period;


                    plans.Add(planEntity);
                }
            }
            return plans;
        }


        public static bool Delplan(string Id)
        {
            using (fitnessEntities dbe = new fitnessEntities())
            {
                var cst = dbe.customers.Where(o => o.plan_id == Id).ToList();
                if (cst.Count == 0)
                {
                    plan plan = dbe.plans.Where(o => o.plan_id.Equals(Id)).SingleOrDefault();
                    dbe.plans.Remove(plan);
                    dbe.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static PlanEntity Detailplan(string Id)
        {

            PlanEntity planEntity = new Entity.PlanEntity();
            using (fitnessEntities dbe = new fitnessEntities())
            {
                plan plan = dbe.plans.Where(o => o.plan_id.Equals(Id)).SingleOrDefault();
                planEntity.plan_id = plan.plan_id;
                planEntity.plan_name = plan.plan_name;
                planEntity.plan_cost = plan.plan_cost;
                planEntity.plan_period = plan.plan_period;

            }
            return planEntity;
        }
    }
}