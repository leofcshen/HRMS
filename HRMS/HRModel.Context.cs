﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyHREntities : DbContext
    {
        public MyHREntities()
            : base("name=MyHREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Absence> Absence { get; set; }
        public virtual DbSet<ApplyDetail> ApplyDetail { get; set; }
        public virtual DbSet<Bulletin> Bulletin { get; set; }
        public virtual DbSet<CheckStatus> CheckStatus { get; set; }
        public virtual DbSet<Cost> Cost { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<LeaveApplication> LeaveApplication { get; set; }
        public virtual DbSet<OnBoardStatus> OnBoardStatus { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Travel_Expense_Application> Travel_Expense_Application { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
