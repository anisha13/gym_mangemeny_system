﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gym.Models.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fitnessEntities : DbContext
    {
        public fitnessEntities()
            : base("name=fitnessEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<equipment> equipments { get; set; }
        public virtual DbSet<plan> plans { get; set; }
        public virtual DbSet<trainer> trainers { get; set; }
        public virtual DbSet<Getaccount> Getaccounts { get; set; }
        public virtual DbSet<Getcustomer> Getcustomers { get; set; }
    }
}
