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
    
    public partial class AmateurSponserDetail
    {
        public int ID { get; set; }
        public int Runner_ID { get; set; }
        public int Sponsor_Id { get; set; }
        public decimal SponsorAmount { get; set; }
    
        public virtual RegistrationDetail RegistrationDetail { get; set; }
        public virtual SponserList SponserList { get; set; }
    }
}
