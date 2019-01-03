namespace ProductivityTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityTypes", "ActivityCategory_Id", "dbo.ActivityCategories");
            DropIndex("dbo.ActivityTypes", new[] { "ActivityCategory_Id" });
            RenameColumn(table: "dbo.ActivityTypes", name: "ActivityCategory_Id", newName: "ActivityCategoryId");
            AlterColumn("dbo.ActivityTypes", "ActivityCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActivityTypes", "ActivityCategoryId");
            AddForeignKey("dbo.ActivityTypes", "ActivityCategoryId", "dbo.ActivityCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityTypes", "ActivityCategoryId", "dbo.ActivityCategories");
            DropIndex("dbo.ActivityTypes", new[] { "ActivityCategoryId" });
            AlterColumn("dbo.ActivityTypes", "ActivityCategoryId", c => c.Int());
            RenameColumn(table: "dbo.ActivityTypes", name: "ActivityCategoryId", newName: "ActivityCategory_Id");
            CreateIndex("dbo.ActivityTypes", "ActivityCategory_Id");
            AddForeignKey("dbo.ActivityTypes", "ActivityCategory_Id", "dbo.ActivityCategories", "Id");
        }
    }
}
