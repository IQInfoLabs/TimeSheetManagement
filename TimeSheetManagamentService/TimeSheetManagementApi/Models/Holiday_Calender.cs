//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeSheetManagementApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Holiday_Calender
    {
        public int Holiday_Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Day { get; set; }
        public string Occasion { get; set; }
        public Nullable<int> Geo_Id { get; set; }
        public Nullable<System.DateTime> created_Date { get; set; }
        public Nullable<System.DateTime> Last_Updated_Date { get; set; }
    
        public virtual Geo_Location Geo_Location { get; set; }
    }
}