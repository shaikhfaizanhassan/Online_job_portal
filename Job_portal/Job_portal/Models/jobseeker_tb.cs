//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Job_portal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class jobseeker_tb
    {
        public jobseeker_tb()
        {
            this.ApplyJob_tb = new HashSet<ApplyJob_tb>();
            this.Education_tb = new HashSet<Education_tb>();
        }
    
        public int JS_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
    
        public virtual ICollection<ApplyJob_tb> ApplyJob_tb { get; set; }
        public virtual ICollection<Education_tb> Education_tb { get; set; }
    }
}
