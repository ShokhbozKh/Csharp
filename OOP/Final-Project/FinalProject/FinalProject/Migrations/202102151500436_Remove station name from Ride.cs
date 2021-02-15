namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovestationnamefromRide : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rides", "StartStation");
            DropColumn("dbo.Rides", "DestinationStation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rides", "DestinationStation", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Rides", "StartStation", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
