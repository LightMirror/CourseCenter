//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseSite.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CorporatesStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CorporatesStatus()
        {
            this.Corporates1 = new HashSet<Corporates>();
        }
    
        public int ID { get; set; }
        public string Status_EngName { get; set; }
        public string Status_AraName { get; set; }
    
        public virtual Corporates Corporates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporates> Corporates1 { get; set; }
    }
}
