﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointOpeOsaaminen.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OpeOsaamisKantaEntities : DbContext
    {
        public OpeOsaamisKantaEntities()
            : base("name=OpeOsaamisKantaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Opettaja> Opettaja { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<Käyttäjät> Käyttäjät { get; set; }
        public virtual DbSet<Yhteistiedot> Yhteistiedot { get; set; }
        public virtual DbSet<OpettajaOsaaminen> OpettajaOsaaminen { get; set; }
        public virtual DbSet<Osaaminen> Osaaminen { get; set; }
    }
}
