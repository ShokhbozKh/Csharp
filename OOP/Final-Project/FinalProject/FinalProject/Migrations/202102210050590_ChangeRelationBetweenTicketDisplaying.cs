namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationBetweenTicketDisplaying : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "IdTicket", "dbo.Displayings");
            DropIndex("dbo.Tickets", new[] { "IdTicket" });
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Tickets", "DisplayingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "IdTicket", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tickets", "IdTicket");
            CreateIndex("dbo.Tickets", "DisplayingId");
            AddForeignKey("dbo.Tickets", "DisplayingId", "dbo.Displayings", "IdDisplaying", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "DisplayingId", "dbo.Displayings");
            DropIndex("dbo.Tickets", new[] { "DisplayingId" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "IdTicket", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "DisplayingId");
            AddPrimaryKey("dbo.Tickets", "IdTicket");
            CreateIndex("dbo.Tickets", "IdTicket");
            AddForeignKey("dbo.Tickets", "IdTicket", "dbo.Displayings", "IdDisplaying");
        }
    }
}
