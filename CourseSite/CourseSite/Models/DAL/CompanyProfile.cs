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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CompanyProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [Display(Name = "English name")]
        public string CompanyNameEng { get; set; }

        [Required]
        [Display(Name = "Arabic name")]
        public string CompanyNameAra { get; set; }

        [Display(Name = "Flat number")]
        public string CompanyAddress_FlatNumber { get; set; }

        [Display(Name = "Street English name")]
        public string CompanyAddress_StreetNameEng { get; set; }

        [Display(Name = "Street Arabic name")]
        public string CompanyAddress_StreetNameAra { get; set; }

        [Display(Name = "District English name")]
        public string CompanyAddress_DistricNameEng { get; set; }

        [Display(Name = "District Arabic name")]
        public string CompanyAddress_DistricNameAr { get; set; }

        [Display(Name = "City English name")]
        public string CompanyAddress_CityNameEng { get; set; }

        [Display(Name = "City Arabic name")]
        public string CompanyAddress_CityNameAra { get; set; }

        [Display(Name = "Country English name")]
        public string CompanyAddress_CountryNameEng { get; set; }

        [Display(Name = "Country Arabic name")]
        public string CompanyAddress_CountryNameAra { get; set; }

        [Display(Name = "Company Phone 1")]
        public string CompanyPhone1 { get; set; }

        [Display(Name = "Company Phone 2")]
        public string CompanyPhone2 { get; set; }

        [Display(Name = "Company email")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Company English summary")]
        public string CompanySummarEng { get; set; }

        [Display(Name = "Company Arabic summary")]
        public string CompanySummaryAra { get; set; }

        [Display(Name = "Company video path")]
        public string CompanyVideoPath { get; set; }

        [Display(Name = "Company image path")]
        public string CompanyImagePath { get; set; }

        [Display(Name = "English Objective")]
        public string CompanyObjectiveEng { get; set; }

        [Display(Name = "Arabic Objective")]
        public string CompanyObjectiveAra { get; set; }

        [Display(Name = "English HeadLine")]
        public string CompanyHeadLineEng { get; set; }

        [Display(Name = "Arabic HeadLine")]
        public string CompanyHeadLineAra { get; set; }
    }

}
