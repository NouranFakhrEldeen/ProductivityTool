namespace ProductivityTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "ActivityType_ID", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityType_ID" });
            RenameColumn(table: "dbo.Activities", name: "ActivityType_ID", newName: "ActivityTypeId");
            AlterColumn("dbo.Activities", "ActivityTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "ActivityTypeId");
            AddForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.Activities", "ActivityRecordsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "ActivityRecordsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            AlterColumn("dbo.Activities", "ActivityTypeId", c => c.Int());
            RenameColumn(table: "dbo.Activities", name: "ActivityTypeId", newName: "ActivityType_ID");
            CreateIndex("dbo.Activities", "ActivityType_ID");
            AddForeignKey("dbo.Activities", "ActivityType_ID", "dbo.ActivityTypes", "ID");
        }
    }
}
