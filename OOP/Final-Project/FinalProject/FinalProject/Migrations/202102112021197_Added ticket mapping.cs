namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedticketmapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        IdTicket = c.Int(nullable: false, identity: true),
                        TicketNumber = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookedByFullname = c.String(),
                        TicketStatus = c.Int(nullable: false),
                        TicketType = c.Int(nullable: false),
                        Bus_IdBus = c.Int(),
                        DiscountReason_IdDiscountReason = c.Int(),
                    })
                .PrimaryKey(t => t.IdTicket)
                .ForeignKey("dbo.Buses", t => t.Bus_IdBus)
                .ForeignKey("dbo.DiscountReasons", t => t.DiscountReason_IdDiscountReason)
                .Index(t => t.Bus_IdBus)
                .Index(t => t.DiscountReason_IdDiscountReason);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "DiscountReason_IdDiscountReason", "dbo.DiscountReasons");
            DropForeignKey("dbo.Tickets", "Bus_IdBus", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "DiscountReason_IdDiscountReason" });
            DropIndex("dbo.Tickets", new[] { "Bus_IdBus" });
            DropTable("dbo.Tickets");
        }
    }
}
