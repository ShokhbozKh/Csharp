namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeassociationbetweendisplayingandschedule : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Displayings", "BusId", "dbo.Buses");
            DropForeignKey("dbo.Tickets", "DisplayingId", "dbo.Displayings");
            DropForeignKey("dbo.Displayings", "RideScheduleId", "dbo.RideSchedules");
            DropIndex("dbo.Displayings", new[] { "RideScheduleId" });
            DropIndex("dbo.Displayings", new[] { "BusId" });
            DropIndex("dbo.Tickets", new[] { "DisplayingId" });
            DropColumn("dbo.Displayings", "IdDisplaying");
            RenameColumn(table: "dbo.Displayings", name: "RideScheduleId", newName: "IdDisplaying");
            DropPrimaryKey("dbo.Displayings");
            AddColumn("dbo.Displayings", "BusName", c => c.String(nullable: false));
            AlterColumn("dbo.Displayings", "IdDisplaying", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Displayings", "IdDisplaying");
            CreateIndex("dbo.Displayings", "IdDisplaying");
            AddForeignKey("dbo.Displayings", "IdDisplaying", "dbo.RideSchedules", "IdRideSchedule");
            DropColumn("dbo.Displayings", "BusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Displayings", "BusId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Displayings", "IdDisplaying", "dbo.RideSchedules");
            DropIndex("dbo.Displayings", new[] { "IdDisplaying" });
            DropPrimaryKey("dbo.Displayings");
            AlterColumn("dbo.Displayings", "IdDisplaying", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Displayings", "BusName");
            AddPrimaryKey("dbo.Displayings", "IdDisplaying");
            RenameColumn(table: "dbo.Displayings", name: "IdDisplaying", newName: "RideScheduleId");
            AddColumn("dbo.Displayings", "IdDisplaying", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Tickets", "DisplayingId");
            CreateIndex("dbo.Displayings", "BusId");
            CreateIndex("dbo.Displayings", "RideScheduleId");
            AddForeignKey("dbo.Displayings", "RideScheduleId", "dbo.RideSchedules", "IdRideSchedule", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "DisplayingId", "dbo.Displayings", "IdDisplaying", cascadeDelete: true);
            AddForeignKey("dbo.Displayings", "BusId", "dbo.Buses", "IdBus", cascadeDelete: true);
        }
    }
}
