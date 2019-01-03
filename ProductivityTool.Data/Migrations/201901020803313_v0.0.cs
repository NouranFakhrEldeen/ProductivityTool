namespace ProductivityTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v00 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SizingUnitID = c.Int(),
                        ActivityType_ID = c.Int(),
                        lkp_SizingUnit_PK_SizingUnitID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityType_ID)
                .ForeignKey("dbo.lkp_SizingUnit", t => t.lkp_SizingUnit_PK_SizingUnitID)
                .Index(t => t.ActivityType_ID)
                .Index(t => t.lkp_SizingUnit_PK_SizingUnitID);
            
            CreateTable(
                "dbo.ActivityRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityDate = c.DateTime(nullable: false, storeType: "date"),
                        ActivityID = c.Int(nullable: false),
                        DemandID = c.Int(),
                        ProjectID = c.Int(),
                        Size = c.Int(),
                        ActualEffort_Hours = c.Int(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Demands", t => t.DemandID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ActivityID)
                .Index(t => t.DemandID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DemandType = c.String(),
                        DemandNumber = c.String(nullable: false),
                        DemandName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ActivityCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ActivityCategories", t => t.ActivityCategory_Id)
                .Index(t => t.ActivityCategory_Id);
            
            CreateTable(
                "dbo.ActivityCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileName = c.String(),
                        COETeamFunctionID = c.Int(nullable: false),
                        COE_TeamFunction_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.COE_TeamFunction", t => t.COE_TeamFunction_ID)
                .Index(t => t.COE_TeamFunction_ID);
            
            CreateTable(
                "dbo.COE_TeamFunction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        COETeamID = c.Int(nullable: false),
                        FunctionName = c.String(nullable: false),
                        COE_Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.COE_Team", t => t.COE_Team_Id)
                .Index(t => t.COE_Team_Id);
            
            CreateTable(
                "dbo.COE_Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NTAccount = c.String(nullable: false),
                        GroupMail = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsFunctionLeader = c.Boolean(),
                        IsTeamLeader = c.Boolean(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.lkp_SizingUnit",
                c => new
                    {
                        PK_SizingUnitID = c.Int(nullable: false, identity: true),
                        SizingUnit = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PK_SizingUnitID);
            
            CreateTable(
                "dbo.RoleProfileActivityCategories",
                c => new
                    {
                        RoleProfile_Id = c.Int(nullable: false),
                        ActivityCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleProfile_Id, t.ActivityCategory_Id })
                .ForeignKey("dbo.RoleProfiles", t => t.RoleProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.ActivityCategories", t => t.ActivityCategory_Id, cascadeDelete: true)
                .Index(t => t.RoleProfile_Id)
                .Index(t => t.ActivityCategory_Id);
            
            CreateTable(
                "dbo.UserRoleProfiles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        RoleProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.RoleProfile_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.RoleProfiles", t => t.RoleProfile_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.RoleProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "lkp_SizingUnit_PK_SizingUnitID", "dbo.lkp_SizingUnit");
            DropForeignKey("dbo.UserRoleProfiles", "RoleProfile_Id", "dbo.RoleProfiles");
            DropForeignKey("dbo.UserRoleProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleProfiles", "COE_TeamFunction_ID", "dbo.COE_TeamFunction");
            DropForeignKey("dbo.COE_TeamFunction", "COE_Team_Id", "dbo.COE_Team");
            DropForeignKey("dbo.RoleProfileActivityCategories", "ActivityCategory_Id", "dbo.ActivityCategories");
            DropForeignKey("dbo.RoleProfileActivityCategories", "RoleProfile_Id", "dbo.RoleProfiles");
            DropForeignKey("dbo.ActivityTypes", "ActivityCategory_Id", "dbo.ActivityCategories");
            DropForeignKey("dbo.Activities", "ActivityType_ID", "dbo.ActivityTypes");
            DropForeignKey("dbo.ActivityRecords", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ActivityRecords", "DemandID", "dbo.Demands");
            DropForeignKey("dbo.ActivityRecords", "ActivityID", "dbo.Activities");
            DropIndex("dbo.UserRoleProfiles", new[] { "RoleProfile_Id" });
            DropIndex("dbo.UserRoleProfiles", new[] { "User_Id" });
            DropIndex("dbo.RoleProfileActivityCategories", new[] { "ActivityCategory_Id" });
            DropIndex("dbo.RoleProfileActivityCategories", new[] { "RoleProfile_Id" });
            DropIndex("dbo.COE_TeamFunction", new[] { "COE_Team_Id" });
            DropIndex("dbo.RoleProfiles", new[] { "COE_TeamFunction_ID" });
            DropIndex("dbo.ActivityTypes", new[] { "ActivityCategory_Id" });
            DropIndex("dbo.ActivityRecords", new[] { "ProjectID" });
            DropIndex("dbo.ActivityRecords", new[] { "DemandID" });
            DropIndex("dbo.ActivityRecords", new[] { "ActivityID" });
            DropIndex("dbo.Activities", new[] { "lkp_SizingUnit_PK_SizingUnitID" });
            DropIndex("dbo.Activities", new[] { "ActivityType_ID" });
            DropTable("dbo.UserRoleProfiles");
            DropTable("dbo.RoleProfileActivityCategories");
            DropTable("dbo.lkp_SizingUnit");
            DropTable("dbo.Users");
            DropTable("dbo.COE_Team");
            DropTable("dbo.COE_TeamFunction");
            DropTable("dbo.RoleProfiles");
            DropTable("dbo.ActivityCategories");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Projects");
            DropTable("dbo.Demands");
            DropTable("dbo.ActivityRecords");
            DropTable("dbo.Activities");
        }
    }
}
