﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVCAppDatabaseEntities : DbContext
    {
        public MVCAppDatabaseEntities()
            : base("name=MVCAppDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CSPDetail> CSPDetails { get; set; }
        public virtual DbSet<CSPPunch> CSPPunches { get; set; }
        public virtual DbSet<KioskTime> KioskTimes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<MainMenu> MainMenus { get; set; }
        public virtual DbSet<MenuAccessright> MenuAccessrights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
