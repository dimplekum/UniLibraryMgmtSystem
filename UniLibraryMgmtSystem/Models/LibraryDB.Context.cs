﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniLibraryMgmtSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryManagementSystemEntities : DbContext
    {
        public LibraryManagementSystemEntities()
            : base("name=LibraryManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<BOOK_CATEGORY> BOOK_CATEGORY { get; set; }
        public virtual DbSet<BOOK_ISSUE> BOOK_ISSUE { get; set; }
        public virtual DbSet<BOOK_RECEIEVED> BOOK_RECEIEVED { get; set; }
        public virtual DbSet<MEMBER> MEMBERs { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<PublicationType> PublicationTypes { get; set; }
        public virtual DbSet<PUBLISHER> PUBLISHERs { get; set; }
    }
}
