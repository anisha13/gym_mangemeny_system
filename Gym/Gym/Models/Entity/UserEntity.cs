using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entity
{
    public class UserEntity
    {
        [Display(Name = "Id")]

        public string id { get; set; }
        [Display(Name = "Name")]

        public string fullname { get; set; }
        [Display(Name = "User Name")]

        public string username { get; set; }
        [Display(Name = "Password")]

        public string password { get; set; }
        [Display(Name = "Type")]

        public string Type { get; set; }
        [Display(Name = "Role")]

        public string Roles { get; set; }
    }


}