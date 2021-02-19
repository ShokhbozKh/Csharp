namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDisplayingTicketAssoc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "DisplayingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "DisplayingId", c => c.Int(nullable: false));
        }
    }
}
