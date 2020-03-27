using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entity
{
    public class MemberEntity
    {
        [Display(Name = "Id")]

        public string customer_id { get; set; }
        [Display(Name = "Name")]

        public string customer_fullname { get; set; }
        [Display(Name = "User Name")]

        public string customer_username { get; set; }
        [Display(Name = "Password")]

        public string customer_password { get; set; }
        [Display(Name = "Type")]

        public string Type { get; set; }
        [Display(Name = "Role")]

        public string Roles { get; set; }

    }


}