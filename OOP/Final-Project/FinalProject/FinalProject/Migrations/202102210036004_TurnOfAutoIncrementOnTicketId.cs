namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnOfAutoIncrementOnTicketId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "TicketNumber");
        }
    }
}
