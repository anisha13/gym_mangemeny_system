using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entity
{
    public class AdminEntity
    {
        [Display(Name = "Id")]
        public string admin_id { get; set; }


        [Display(Name = "User Name")]
        public string admin_username { get; set; }


        [Display(Name = "Name")]
       
        public string admin_fullname { get; set; }
        [Display(Name = "Password")]
        



        public string admin_password { get; set; }

    }
}