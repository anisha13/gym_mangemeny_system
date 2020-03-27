using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entity
{
    public class TrainerEntity

    {
        [Display(Name = "Id")]
      //  [StringLength(3, ErrorMessage = "Do not enter more than 3 characters")]

        public string trainer_id { get; set; }
        [Display(Name = "Name")]
        //[RegularExpression(@"^[a-zA-Z\s]+$")]

        public string trainer_name { get; set; }
        [Display(Name = "Contact")]
        //[RegularExpression(@"^[0-9\s]+$")]
        //[MaxLength(10)]


        public string trainer_contact { get; set; }
        [Display(Name = "Address")]

        public string trainer_address { get; set; }
        [Display(Name = "Photo")]

        public string trainer_photo { get; set; }
        public HttpPostedFileBase PhotoFile { get; set; }



    }
}