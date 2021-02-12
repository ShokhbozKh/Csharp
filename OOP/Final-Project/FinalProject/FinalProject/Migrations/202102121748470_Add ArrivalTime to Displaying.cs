namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArrivalTimetoDisplaying : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Displayings", "ArrivalTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Displayings", "ArrivalTime");
        }
    }
}
