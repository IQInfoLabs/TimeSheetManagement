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
    
    public partial class Employee_Leaves
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee_Leaves()
        {
            this.TimeSheets = new HashSet<TimeSheet>();
        }
    
        public int Leave_Id { get; set; }
        public Nullable<int> Employee_Id { get; set; }
        public Nullable<int> Leave_Type_Id { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<System.DateTime> created_Date { get; set; }
        public Nullable<System.DateTime> Last_Updated_Date { get; set; }
    
        public virtual Employee_Details Employee_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
    }
}