namespace ProductivityTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v07 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "ActivityCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "ActivityCategoryId", c => c.Int(nullable: false));
        }
    }
}
