//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrestonClub.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RunnerStatu
    {
        public int ID { get; set; }
        public Nullable<int> Runner_ID { get; set; }
        public string RunningStatus { get; set; }
        public string FinishedTime { get; set; }
    
        public virtual RegistrationDetail RegistrationDetail { get; set; }
    }
}
