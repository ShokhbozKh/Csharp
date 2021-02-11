namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDisplayingintroducedbusseatasmiddlemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusSeats",
                c => new
                    {
                        BusSeatId = c.Int(nullable: false, identity: true),
                        BusId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        IsAvialable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusSeatId)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.BusId)
                .Index(t => t.SeatId);
            
            CreateTable(
                "dbo.Displayings",
                c => new
                    {
                        IdDisplaying = c.Int(nullable: false, identity: true),
                        StandardPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvialableSeats = c.Int(nullable: false),
                        IsDeparted = c.Boolean(nullable: false),
                        RideId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        BusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDisplaying)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.Rides", t => t.RideId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.RideId)
                .Index(t => t.TicketId)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.TicketClassAttributes",
                c => new
                    {
                        IdTicketClassAttribute = c.Int(nullable: false, identity: true),
                        StandardPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdTicketClassAttribute);
            
            AddColumn("dbo.Tickets", "DepartureTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "ArrivalTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "Seat_IdSeat", c => c.Int());
            AddColumn("dbo.Tickets", "TicketClassAttribute_IdTicketClassAttribute", c => c.Int());
            CreateIndex("dbo.Tickets", "Seat_IdSeat");
            CreateIndex("dbo.Tickets", "TicketClassAttribute_IdTicketClassAttribute");
            AddForeignKey("dbo.Tickets", "Seat_IdSeat", "dbo.Seats", "IdSeat");
            AddForeignKey("dbo.Tickets", "TicketClassAttribute_IdTicketClassAttribute", "dbo.TicketClassAttributes", "IdTicketClassAttribute");
            DropColumn("dbo.Seats", "BusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "BusId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Displayings", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "TicketClassAttribute_IdTicketClassAttribute", "dbo.TicketClassAttributes");
            DropForeignKey("dbo.Tickets", "Seat_IdSeat", "dbo.Seats");
            DropForeignKey("dbo.Displayings", "RideId", "dbo.Rides");
            DropForeignKey("dbo.Displayings", "BusId", "dbo.Buses");
            DropForeignKey("dbo.BusSeats", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.BusSeats", "BusId", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "TicketClassAttribute_IdTicketClassAttribute" });
            DropIndex("dbo.Tickets", new[] { "Seat_IdSeat" });
            DropIndex("dbo.Displayings", new[] { "BusId" });
            DropIndex("dbo.Displayings", new[] { "TicketId" });
            DropIndex("dbo.Displayings", new[] { "RideId" });
            DropIndex("dbo.BusSeats", new[] { "SeatId" });
            DropIndex("dbo.BusSeats", new[] { "BusId" });
            DropColumn("dbo.Tickets", "TicketClassAttribute_IdTicketClassAttribute");
            DropColumn("dbo.Tickets", "Seat_IdSeat");
            DropColumn("dbo.Tickets", "ArrivalTime");
            DropColumn("dbo.Tickets", "DepartureTime");
            DropTable("dbo.TicketClassAttributes");
            DropTable("dbo.Displayings");
            DropTable("dbo.BusSeats");
        }
    }
}
