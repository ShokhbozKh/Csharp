namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroduceTicketSeatsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketSeats",
                c => new
                    {
                        IdTicketSeats = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTicketSeats)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.SeatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketSeats", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketSeats", "SeatId", "dbo.Seats");
            DropIndex("dbo.TicketSeats", new[] { "SeatId" });
            DropIndex("dbo.TicketSeats", new[] { "TicketId" });
            DropTable("dbo.TicketSeats");
        }
    }
}
