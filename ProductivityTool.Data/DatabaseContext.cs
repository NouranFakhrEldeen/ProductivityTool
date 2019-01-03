namespace ProductivityTool.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityCategory> ActivityCategories { get; set; }
        public virtual DbSet<ActivityRecord> ActivityRecords { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<COE_Team> COE_Team { get; set; }
        public virtual DbSet<COE_TeamFunction> COE_TeamFunction { get; set; }
        public virtual DbSet<Demand> Demands { get; set; }
        public virtual DbSet<lkp_SizingUnit> lkp_SizingUnit { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<RoleProfile> RoleProfiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
       

       
    }
}
