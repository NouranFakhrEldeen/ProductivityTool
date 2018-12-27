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
        public virtual DbSet<RoleProfileActivityCategory> RoleProfileActivityCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRolesProfile> UsersRolesProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Activity1)
                .IsFixedLength();

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityRecords)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.FK_ActivityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityCategory>()
                .HasMany(e => e.ActivityTypes)
                .WithRequired(e => e.ActivityCategory)
                .HasForeignKey(e => e.FK_ActivityCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityCategory>()
                .HasMany(e => e.RoleProfileActivityCategories)
                .WithOptional(e => e.ActivityCategory)
                .HasForeignKey(e => e.FK_ActivityCategoryID);

            modelBuilder.Entity<ActivityType>()
                .HasMany(e => e.Activities)
                .WithOptional(e => e.ActivityType)
                .HasForeignKey(e => e.FK_ActivityTypeID);

            modelBuilder.Entity<COE_Team>()
                .HasMany(e => e.COE_TeamFunction)
                .WithRequired(e => e.COE_Team)
                .HasForeignKey(e => e.FK_COETeamID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COE_TeamFunction>()
                .HasMany(e => e.RoleProfiles)
                .WithRequired(e => e.COE_TeamFunction)
                .HasForeignKey(e => e.FK_COETeamFunctionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demand>()
                .Property(e => e.DemandType)
                .IsFixedLength();

            modelBuilder.Entity<Demand>()
                .Property(e => e.DemandNumber)
                .IsFixedLength();

            modelBuilder.Entity<Demand>()
                .Property(e => e.DemandName)
                .IsFixedLength();

            modelBuilder.Entity<Demand>()
                .HasMany(e => e.ActivityRecords)
                .WithOptional(e => e.Demand)
                .HasForeignKey(e => e.FK_DemandID);

            modelBuilder.Entity<lkp_SizingUnit>()
                .HasMany(e => e.Activities)
                .WithOptional(e => e.lkp_SizingUnit)
                .HasForeignKey(e => e.FK_SizingUnitID);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ActivityRecords)
                .WithOptional(e => e.Project)
                .HasForeignKey(e => e.FK_ProjectID);

            modelBuilder.Entity<RoleProfile>()
                .Property(e => e.ProfileName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RoleProfile>()
                .HasMany(e => e.RoleProfileActivityCategories)
                .WithOptional(e => e.RoleProfile)
                .HasForeignKey(e => e.FK_RoleProfileID);

            modelBuilder.Entity<RoleProfile>()
                .HasMany(e => e.UsersRolesProfiles)
                .WithRequired(e => e.RoleProfile)
                .HasForeignKey(e => e.FK_RoleProfileID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.AspnetUserID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UsersRolesProfiles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
