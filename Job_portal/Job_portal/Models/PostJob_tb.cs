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
    
    public partial class PostJob_tb
    {
        public PostJob_tb()
        {
            this.ApplyJob_tb = new HashSet<ApplyJob_tb>();
        }
    
        public int JobID { get; set; }
        public Nullable<int> Company_ID { get; set; }
        public Nullable<int> job_cat_id { get; set; }
        public string RequiredSkill { get; set; }
        public string Role { get; set; }
        public string Min_Qualification { get; set; }
        public string ExtraSkill { get; set; }
        public string Max_age { get; set; }
        public Nullable<int> Expected_salary { get; set; }
        public Nullable<int> Job_location { get; set; }
        public string Working_Hour { get; set; }
        public string Job_Desc { get; set; }
        public Nullable<System.DateTime> LastApplyDate { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string Contact_person { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> JobStatus { get; set; }
        public string applied { get; set; }
    
        public virtual ICollection<ApplyJob_tb> ApplyJob_tb { get; set; }
        public virtual Company_tb Company_tb { get; set; }
        public virtual job_categorytb job_categorytb { get; set; }
        public virtual Job_location Job_location1 { get; set; }
    }
}
