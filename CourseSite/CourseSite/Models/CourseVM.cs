using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseSite.Models
{
    public class CourseVM
    {

        public int Id { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "CourseName")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.FAQ), ErrorMessageResourceName = "RequiredFiled")]
        public string CourseNameEn { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "CourseNameAr")]
        [Required(ErrorMessageResourceType = typeof(CourseSite.App_GlobalResources.FAQ), ErrorMessageResourceName = "RequiredFiled")]
        public string CourseNameAr { get; set; }
        [Display(Name = "Vedio Path")]
        public string CourseVedioPath { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "ImagePath")]
        public string CourseImgPath { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "Objective")]
        public string CourseObjectiveEn { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "ObjectiveAr")]
        public string CourseObjectiveAr { get; set; }
        [Required]
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "Summary")]
        public string CourseSumeryEn { get; set; }
        [Required]
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "SummaryAr")]
        public string CourseSumeryAr { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "Content")]
        public string CourseEnglishContent { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "ContentAr")]
        public string CourseArabicContentPath { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "Status")]
        public Nullable<int> CourseStatusID { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "TotalHour")]
        public Nullable<decimal> CourseTotalHour { get; set; }
        [Display(ResourceType = typeof(CourseSite.App_GlobalResources.Main), Name = "Cost")]
        public Nullable<decimal> CourseOrignalCost { get; set; }
        public Nullable<System.DateTime> CourseCreationDate { get; set; }
        public string CourseCreationUsers { get; set; }
        public Nullable<System.DateTime> CourseModifyDate { get; set; }
        public string Course_modifyUsers { get; set; }
        public Nullable<bool> Course_ISInMain { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public SelectList CourseStatus { get; set; }

    }
}