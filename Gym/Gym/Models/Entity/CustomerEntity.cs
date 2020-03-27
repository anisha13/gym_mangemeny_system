using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entity
{
    public class CustomerEntity
    { 
        [Display(Name = "Id")]
        
       // [StringLength(3, ErrorMessage = "Do not enter more than 3 characters")]


        public string customer_id { get; set; }
    [Display(Name = "Name")]
        //[RegularExpression(@"^[a-zA-Z\s]+$")]

        public string customer_fullname { get; set; }
    [Display(Name = "Plan Id")]

    public string plan_id { get; set; }
    [Display(Name = "Plan Name")]

    public string plan_name { get; set; }
    [Display(Name = "Trainer Id")]

    public string trainer_id { get; set; }
    [Display(Name = "Trainer Name")]

    public string trainer_name { get; set; }
    [Display(Name = "Address")]

    public string customer_address { get; set; }
    [Display(Name = "Phone")]
       // [RegularExpression(@"^[0-9\s]+$")]
        //[MaxLength(10)]


        public string customer_phone { get; set; }
    [Display(Name = "Photo")]

    public string customer_photo { get; set; }
        public HttpPostedFileBase PhotoFile { get; set; }



        [Display(Name = "Gender")]

    public string customer_gender { get; set; }
    [Display(Name = "Joined Date")]

    public System.DateTime customer_joindate { get; set; }
        [Display(Name = "User Name")]
       // [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]

        public string customer_username { get; set; }
        [Display(Name = "Password")]

        public string customer_password { get; set; }

    }
}
