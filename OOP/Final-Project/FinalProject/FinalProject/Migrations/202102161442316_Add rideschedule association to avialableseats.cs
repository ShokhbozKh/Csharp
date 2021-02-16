namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addridescheduleassociationtoavialableseats : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RideSchedules", "AvialableSeatsId", "dbo.AvialableSeats");
            DropIndex("dbo.RideSchedules", new[] { "AvialableSeatsId" });
            DropPrimaryKey("dbo.AvialableSeats");
            AddColumn("dbo.AvialableSeats", "AvialableSeatsId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.AvialableSeats", "RideScheduleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AvialableSeats", "AvialableSeatsId");
            CreateIndex("dbo.AvialableSeats", "RideScheduleId");
            AddForeignKey("dbo.AvialableSeats", "RideScheduleId", "dbo.RideSchedules", "IdRideSchedule", cascadeDelete: true);
            DropColumn("dbo.AvialableSeats", "BusSeatId");
            DropColumn("dbo.RideSchedules", "AvialableSeatsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RideSchedules", "AvialableSeatsId", c => c.Int(nullable: false));
            AddColumn("dbo.AvialableSeats", "BusSeatId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AvialableSeats", "RideScheduleId", "dbo.RideSchedules");
            DropIndex("dbo.AvialableSeats", new[] { "RideScheduleId" });
            DropPrimaryKey("dbo.AvialableSeats");
            DropColumn("dbo.AvialableSeats", "RideScheduleId");
            DropColumn("dbo.AvialableSeats", "AvialableSeatsId");
            AddPrimaryKey("dbo.AvialableSeats", "BusSeatId");
            CreateIndex("dbo.RideSchedules", "AvialableSeatsId");
            AddForeignKey("dbo.RideSchedules", "AvialableSeatsId", "dbo.AvialableSeats", "BusSeatId", cascadeDelete: true);
        }
    }
}
