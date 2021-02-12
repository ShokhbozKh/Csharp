namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMiddlemodelforrideandseats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvialableSeats",
                c => new
                    {
                        BusSeatId = c.Int(nullable: false, identity: true),
                        RideId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        IsAvialable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusSeatId)
                .ForeignKey("dbo.Rides", t => t.RideId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.RideId)
                .Index(t => t.SeatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvialableSeats", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.AvialableSeats", "RideId", "dbo.Rides");
            DropIndex("dbo.AvialableSeats", new[] { "SeatId" });
            DropIndex("dbo.AvialableSeats", new[] { "RideId" });
            DropTable("dbo.AvialableSeats");
        }
    }
}
