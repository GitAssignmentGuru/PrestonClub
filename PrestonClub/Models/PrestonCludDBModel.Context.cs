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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrestonClubDBEntities : DbContext
    {
        public PrestonClubDBEntities()
            : base("name=PrestonClubDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AmateurSponserDetail> AmateurSponserDetails { get; set; }
        public virtual DbSet<ParticipantDetail> ParticipantDetails { get; set; }
        public virtual DbSet<RegistrationDetail> RegistrationDetails { get; set; }
        public virtual DbSet<RunnerStatu> RunnerStatus { get; set; }
        public virtual DbSet<SponserList> SponserLists { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Volunteer_Types> Volunteer_Types { get; set; }
    }
}
