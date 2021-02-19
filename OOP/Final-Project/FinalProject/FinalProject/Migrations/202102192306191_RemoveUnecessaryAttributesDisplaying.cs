namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnecessaryAttributesDisplaying : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Displayings", "DepartureTime");
            DropColumn("dbo.Displayings", "ArrivalTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Displayings", "ArrivalTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Displayings", "DepartureTime", c => c.DateTime(nullable: false));
        }
    }
}
