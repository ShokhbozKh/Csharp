namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssocBetweenDisplayingRideSchedule : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Displayings", "RideScheduleId", "dbo.RideSchedules");
            DropIndex("dbo.Displayings", new[] { "RideScheduleId" });
            //DropColumn("dbo.Displayings", "IdDisplaying");
            //RenameColumn(table: "dbo.Displayings", name: "RideScheduleId", newName: "IdDisplaying");
            DropPrimaryKey("dbo.Displayings");
            AlterColumn("dbo.Displayings", "IdDisplaying", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Displayings", "IdDisplaying");
            CreateIndex("dbo.Displayings", "IdDisplaying");
            AddForeignKey("dbo.Displayings", "IdDisplaying", "dbo.RideSchedules", "IdRideSchedule");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Displayings", "IdDisplaying", "dbo.RideSchedules");
            DropIndex("dbo.Displayings", new[] { "IdDisplaying" });
            DropPrimaryKey("dbo.Displayings");
            AlterColumn("dbo.Displayings", "IdDisplaying", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Displayings", "IdDisplaying");
            RenameColumn(table: "dbo.Displayings", name: "IdDisplaying", newName: "RideScheduleId");
            AddColumn("dbo.Displayings", "IdDisplaying", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Displayings", "RideScheduleId");
            AddForeignKey("dbo.Displayings", "RideScheduleId", "dbo.RideSchedules", "IdRideSchedule", cascadeDelete: true);
        }
    }
}
