namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeavialableseatsmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AvialableSeats", "RideId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AvialableSeats", "RideId", c => c.Int(nullable: false));
        }
    }
}
