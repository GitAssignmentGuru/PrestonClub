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
    
    public partial class RegistrationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistrationDetail()
        {
            this.AmateurSponserDetails = new HashSet<AmateurSponserDetail>();
            this.RunnerStatus = new HashSet<RunnerStatu>();
        }
    
        public int ID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public int ParticipantsID { get; set; }
        public Nullable<int> WorldRanking { get; set; }
        public Nullable<int> Volunteer_ID { get; set; }
        public string password { get; set; }
        public string UserType { get; set; }
        public string costume { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmateurSponserDetail> AmateurSponserDetails { get; set; }
        public virtual ParticipantDetail ParticipantDetail { get; set; }
        public virtual Volunteer_Types Volunteer_Types { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RunnerStatu> RunnerStatus { get; set; }
    }
}