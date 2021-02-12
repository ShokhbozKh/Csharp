namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeassociationbetweenticketanddisplayingto11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Displayings", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Displayings", new[] { "TicketId" });
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Users", "PassportId", c => c.String());
            AlterColumn("dbo.Tickets", "IdTicket", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tickets", "IdTicket");
            CreateIndex("dbo.Tickets", "IdTicket");
            AddForeignKey("dbo.Tickets", "IdTicket", "dbo.Displayings", "IdDisplaying");
            DropColumn("dbo.Displayings", "TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Displayings", "TicketId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "IdTicket", "dbo.Displayings");
            DropIndex("dbo.Tickets", new[] { "IdTicket" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "IdTicket", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "PassportId");
            AddPrimaryKey("dbo.Tickets", "IdTicket");
            CreateIndex("dbo.Displayings", "TicketId");
            AddForeignKey("dbo.Displayings", "TicketId", "dbo.Tickets", "IdTicket", cascadeDelete: true);
        }
    }
}
