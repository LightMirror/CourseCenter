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
    using System.Web;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            this.GroupCustomers = new HashSet<GroupCustomers>();
        }
    
        public int ID { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "CutomEnName")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        [MaxLength(200, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_EngName { get; set; }

        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "CutomArName")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledISRequired")]
        [MaxLength(200, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_AraName { get; set; }

        [Phone]
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Phone")]
        [MaxLength(14, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_Phone { get; set; }

        [Phone]
        [Required]
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Mobile")]
        [MaxLength(14, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]


        public string Customer_Mobile { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "BirthDate")]
        public Nullable<System.DateTime> Customer_Birthdate { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Address")]
        [MaxLength(300, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_Address { get; set; }
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Email")]
        [MaxLength(250, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_Email { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Comment")]
        [MaxLength(250, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_Comment { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Gender")]
        public Nullable<int> Customer_GenderId { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "ImagePath")]
        public string Customer_imagePath { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Nid")]
        [MaxLength(15, ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.Instractors), ErrorMessageResourceName = "FiledMaxLengtt")]
        public string Customer_Nid { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Cutomers), Name = "Corporate")]
        public Nullable<int> Customer_CorporateID { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Status")]
        public Nullable<int> Customer_statusID { get; set; }

        public virtual Corporates Corporates { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Status")]
        public virtual CustomerStatus CustomerStatus { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "ImagePath")]
        public HttpPostedFileBase ImageUpload { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Instractors), Name = "Instractor_Gender")]
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupCustomers> GroupCustomers { get; set; }
    }
}
