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

    public partial class attendance
    {
        public int AID { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<System.TimeSpan> checkIn { get; set; }
        public Nullable<System.TimeSpan> checkOut { get; set; }
        public string EID { get; set; }

        public virtual employee employee { get; set; }
    }
}
