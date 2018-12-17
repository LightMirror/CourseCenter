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
    using System.ComponentModel.DataAnnotations;
    using System.Security.AccessControl;

    public partial class Instractors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instractors()
        {
            this.Course_Instractors = new HashSet<Course_Instractors>();
        }
    
        public int ID { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_EngName")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        [MaxLength(200,ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName= "FiledMaxLengtt")]
        public string Instractor_EngName { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_AraName")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        [MaxLength(200, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Instractor_AraName { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Address")]        
        [MaxLength(500, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Instractor_Address { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Mobile")]        
        public string Instractor_Mobile { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_phone")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        public string Instractor_phone { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Email")]        
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        public string Instractor_Email { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Status")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        public Nullable<int> Instractor_StatusID { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Gender")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        public Nullable<int> Instractor_GenderID { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Birthdate")]        
        public Nullable<System.DateTime> Instractor_Birthdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Instractors> Course_Instractors { get; set; }
        public virtual Gender Gender { get; set; }        
        public virtual InstractorStatus InstractorStatus { get; set; }
    }
}
