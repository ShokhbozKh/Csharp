namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRideLocationRideStopmodelmapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        IdLocation = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.IdLocation);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        IdRide = c.Int(nullable: false, identity: true),
                        TotalHours = c.Double(nullable: false),
                        DestinationPoint_IdLocation = c.Int(),
                        StartPoint_IdLocation = c.Int(),
                    })
                .PrimaryKey(t => t.IdRide)
                .ForeignKey("dbo.Locations", t => t.DestinationPoint_IdLocation)
                .ForeignKey("dbo.Locations", t => t.StartPoint_IdLocation)
                .Index(t => t.DestinationPoint_IdLocation)
                .Index(t => t.StartPoint_IdLocation);
            
            CreateTable(
                "dbo.RideStops",
                c => new
                    {
                        IdRideStop = c.Int(nullable: false, identity: true),
                        Location_IdLocation = c.Int(),
                        Ride_IdRide = c.Int(),
                    })
                .PrimaryKey(t => t.IdRideStop)
                .ForeignKey("dbo.Locations", t => t.Location_IdLocation)
                .ForeignKey("dbo.Rides", t => t.Ride_IdRide)
                .Index(t => t.Location_IdLocation)
                .Index(t => t.Ride_IdRide);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RideStops", "Ride_IdRide", "dbo.Rides");
            DropForeignKey("dbo.RideStops", "Location_IdLocation", "dbo.Locations");
            DropForeignKey("dbo.Rides", "StartPoint_IdLocation", "dbo.Locations");
            DropForeignKey("dbo.Rides", "DestinationPoint_IdLocation", "dbo.Locations");
            DropIndex("dbo.RideStops", new[] { "Ride_IdRide" });
            DropIndex("dbo.RideStops", new[] { "Location_IdLocation" });
            DropIndex("dbo.Rides", new[] { "StartPoint_IdLocation" });
            DropIndex("dbo.Rides", new[] { "DestinationPoint_IdLocation" });
            DropTable("dbo.RideStops");
            DropTable("dbo.Rides");
            DropTable("dbo.Locations");
        }
    }
}
