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
    
    public partial class Customerabsent
    {
        public int Customerabsent_ID { get; set; }
        public Nullable<System.DateTime> Customerabsent_Date { get; set; }
        public Nullable<bool> Customerabsent_ISabsent { get; set; }
        public Nullable<int> Customerabsent_GroupCustomerID { get; set; }
    
        public virtual GroupCustomers GroupCustomers { get; set; }
    }
}
