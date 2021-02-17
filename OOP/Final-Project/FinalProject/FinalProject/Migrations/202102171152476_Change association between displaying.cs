namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeassociationbetweendisplaying : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Displayings", "BusId", "dbo.Buses");
            DropForeignKey("dbo.Displayings", "RideId", "dbo.Rides");
            DropIndex("dbo.Displayings", new[] { "RideId" });
            DropIndex("dbo.Displayings", new[] { "BusId" });
            AddColumn("dbo.Displayings", "RideScheduleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Displayings", "RideScheduleId");
            AddForeignKey("dbo.Displayings", "RideScheduleId", "dbo.RideSchedules", "IdRideSchedule", cascadeDelete: true);
            DropColumn("dbo.Displayings", "RideId");
            DropColumn("dbo.Displayings", "BusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Displayings", "BusId", c => c.Int(nullable: false));
            AddColumn("dbo.Displayings", "RideId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Displayings", "RideScheduleId", "dbo.RideSchedules");
            DropIndex("dbo.Displayings", new[] { "RideScheduleId" });
            DropColumn("dbo.Displayings", "RideScheduleId");
            CreateIndex("dbo.Displayings", "BusId");
            CreateIndex("dbo.Displayings", "RideId");
            AddForeignKey("dbo.Displayings", "RideId", "dbo.Rides", "IdRide", cascadeDelete: true);
            AddForeignKey("dbo.Displayings", "BusId", "dbo.Buses", "IdBus", cascadeDelete: true);
        }
    }
}
