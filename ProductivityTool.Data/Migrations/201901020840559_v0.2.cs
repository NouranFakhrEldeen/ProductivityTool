namespace ProductivityTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ActivityRecordsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "ActivityRecordsId");
        }
    }
}
