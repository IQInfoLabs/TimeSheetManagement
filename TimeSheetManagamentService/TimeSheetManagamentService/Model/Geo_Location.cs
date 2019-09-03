//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeSheetManagamentService.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Geo_Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Geo_Location()
        {
            this.Addresses = new HashSet<Address>();
            this.Employee_Project_Details = new HashSet<Employee_Project_Details>();
            this.Holiday_Calender = new HashSet<Holiday_Calender>();
        }
    
        public int Geo_Id { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> created_Date { get; set; }
        public Nullable<System.DateTime> Last_Updated_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Project_Details> Employee_Project_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Holiday_Calender> Holiday_Calender { get; set; }
    }
}