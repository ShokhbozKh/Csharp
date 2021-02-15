namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmodelsforschedulingrides : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvialableSeats", "RideId", "dbo.Rides");
            DropIndex("dbo.AvialableSeats", new[] { "RideId" });
            CreateTable(
                "dbo.RideDates",
                c => new
                    {
                        IdRideData = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        RideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRideData);
            
            CreateTable(
                "dbo.RideSchedules",
                c => new
                    {
                        IdRideSchedule = c.Int(nullable: false, identity: true),
                        RideDateId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        AvialableSeatsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRideSchedule)
                .ForeignKey("dbo.AvialableSeats", t => t.AvialableSeatsId, cascadeDelete: true)
                .ForeignKey("dbo.RideDates", t => t.RideDateId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.RideDateId)
                .Index(t => t.ScheduleId)
                .Index(t => t.AvialableSeatsId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        IdRideSchedule = c.Int(nullable: false, identity: true),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdRideSchedule);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RideSchedules", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.RideSchedules", "RideDateId", "dbo.RideDates");
            DropForeignKey("dbo.RideSchedules", "AvialableSeatsId", "dbo.AvialableSeats");
            DropIndex("dbo.RideSchedules", new[] { "AvialableSeatsId" });
            DropIndex("dbo.RideSchedules", new[] { "ScheduleId" });
            DropIndex("dbo.RideSchedules", new[] { "RideDateId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.RideSchedules");
            DropTable("dbo.RideDates");
            CreateIndex("dbo.AvialableSeats", "RideId");
            AddForeignKey("dbo.AvialableSeats", "RideId", "dbo.Rides", "IdRide", cascadeDelete: true);
        }
    }
}
