//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gym.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainer()
        {
            this.customers = new HashSet<customer>();
        }
    
        public string trainer_id { get; set; }
        public string trainer_name { get; set; }
        public string trainer_contact { get; set; }
        public string trainer_address { get; set; }
        public string trainer_photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers { get; set; }
    }
}
