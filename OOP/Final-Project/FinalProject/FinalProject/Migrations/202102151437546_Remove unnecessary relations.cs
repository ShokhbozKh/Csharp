namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeunnecessaryrelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "BusId", "dbo.Buses");
            DropForeignKey("dbo.Tickets", "SeatId", "dbo.Seats");
            DropIndex("dbo.Tickets", new[] { "BusId" });
            DropIndex("dbo.Tickets", new[] { "SeatId" });
            DropColumn("dbo.Tickets", "BookedByFullname");
            DropColumn("dbo.Tickets", "DepartureTime");
            DropColumn("dbo.Tickets", "ArrivalTime");
            DropColumn("dbo.Tickets", "BusId");
            DropColumn("dbo.Tickets", "SeatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "SeatId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "BusId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "ArrivalTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "DepartureTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "BookedByFullname", c => c.String());
            CreateIndex("dbo.Tickets", "SeatId");
            CreateIndex("dbo.Tickets", "BusId");
            AddForeignKey("dbo.Tickets", "SeatId", "dbo.Seats", "IdSeat", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "BusId", "dbo.Buses", "IdBus", cascadeDelete: true);
        }
    }
}
