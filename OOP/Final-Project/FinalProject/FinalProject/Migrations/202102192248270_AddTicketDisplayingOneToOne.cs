namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketDisplayingOneToOne : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "IdTicket", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tickets", "IdTicket");
            CreateIndex("dbo.Tickets", "IdTicket");
            AddForeignKey("dbo.Tickets", "IdTicket", "dbo.Displayings", "IdDisplaying");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "IdTicket", "dbo.Displayings");
            DropIndex("dbo.Tickets", new[] { "IdTicket" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "IdTicket", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tickets", "IdTicket");
        }
    }
}
