using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entity
{
    public class PlanEntity
    {
        [Display(Name ="Id")]
     //   [StringLength(3, ErrorMessage = "Do not enter more than 3 characters")]
        public string plan_id { get; set; }

        [Display(Name = "Name")]
       // [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string plan_name { get; set; }

        [Display(Name = "Cost")]
       // [RegularExpression(@"^[0-9\s]+$")]
        


        public string plan_cost { get; set; }
        [Display(Name = "Period")]



        public string plan_period { get; set; }

    }
}