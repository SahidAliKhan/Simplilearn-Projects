﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DigitalRetailersDBEntities : DbContext
    {
        public DigitalRetailersDBEntities()
            : base("name=DigitalRetailersDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<lapbrand> lapbrands { get; set; }
        public virtual DbSet<logintable> logintables { get; set; }
        public virtual DbSet<placedorder> placedorders { get; set; }
    }
}
