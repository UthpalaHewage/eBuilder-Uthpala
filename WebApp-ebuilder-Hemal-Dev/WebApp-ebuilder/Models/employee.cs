//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp_ebuilder.Models
{
    using System;
    using System.Collections.Generic;

    public partial class employee
    {
        public employee()
        {
            this.attendances = new HashSet<attendance>();
            this.leavs = new HashSet<leav>();
            this.tasks = new HashSet<task>();
            this.duty_leave = new HashSet<duty_leave>();
            this.employee1 = new HashSet<employee>();
            this.employees = new HashSet<employee>();
            this.notifications = new HashSet<notification>();
            this.approvals = new HashSet<approval>();
        }

        public string EID { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<bool> emailVerified { get; set; }
        public string activationCode { get; set; }
        public System.DateTime dob { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string gender { get; set; }
        public string homeNo { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string jobCategory { get; set; }

        internal virtual ICollection<attendance> attendances { get; set; }
        internal virtual ICollection<leav> leavs { get; set; }
        internal virtual ICollection<task> tasks { get; set; }
        internal virtual ICollection<duty_leave> duty_leave { get; set; }
        internal virtual ICollection<employee> employee1 { get; set; }
        internal virtual ICollection<employee> employees { get; set; }
        internal virtual ICollection<notification> notifications { get; set; }
        internal virtual ICollection<approval> approvals { get; set; }
    }
}