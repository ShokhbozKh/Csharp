namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbusconstrainttodisplaying : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Displayings", "BusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Displayings", "BusId");
            AddForeignKey("dbo.Displayings", "BusId", "dbo.Buses", "IdBus", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Displayings", "BusId", "dbo.Buses");
            DropIndex("dbo.Displayings", new[] { "BusId" });
            DropColumn("dbo.Displayings", "BusId");
        }
    }
}
