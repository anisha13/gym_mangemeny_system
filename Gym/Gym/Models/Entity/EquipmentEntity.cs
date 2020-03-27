using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Gym.Models.Entity
{
    public class EquipmentEntity
    {
        [Display(Name = "Id")]
   //     [StringLength(3, ErrorMessage = "Do not enter more than 3 characters")]
        public string equipment_id { get; set; }
        [Display(Name = "Name")]
     //   [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string equipment_name { get; set; }
        [Display(Name = "Quantity")]
       // [RegularExpression(@"^[0-9\s]+$")]
        //[MaxLength(2)]

        public string equipment_quantity { get; set; }
        [Display(Name = "Cost")]
        //[RegularExpression(@"^[0-9\s]+$")]
       // [MaxLength(2)]

        public int equipment_cost { get; set; }
        [Display(Name = "Photo")]
        public string equipment_photo { get; set; }
        public HttpPostedFileBase PhotoFile { get; set; }

    }
}