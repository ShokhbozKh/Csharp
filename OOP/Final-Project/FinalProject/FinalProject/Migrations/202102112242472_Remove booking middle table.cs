namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removebookingmiddletable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "TicketId" });
            DropTable("dbo.Bookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        IdBooking = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdBooking);
            
            CreateIndex("dbo.Bookings", "TicketId");
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "TicketId", "dbo.Tickets", "IdTicket", cascadeDelete: true);
        }
    }
}
