﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KuryeTakip.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KuryeTakipEntityContainer : DbContext
    {
        public KuryeTakipEntityContainer()
            : base("name=KuryeTakipEntityContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kurye> KuryeSet { get; set; }
        public virtual DbSet<Restoran> RestoranSet { get; set; }
        public virtual DbSet<Siparis> SiparisSet { get; set; }
        public virtual DbSet<Bolge> BolgeSet { get; set; }
        public virtual DbSet<Ayar> AyarSet { get; set; }
        public virtual DbSet<OdemeYontemi> OdemeYontemiSet { get; set; }
        public virtual DbSet<Kullanici> KullaniciSet { get; set; }
    }
}
