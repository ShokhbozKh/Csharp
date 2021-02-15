namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrightrelationtoschedule : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RideDates", "RideId");
            AddForeignKey("dbo.RideDates", "RideId", "dbo.Rides", "IdRide", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RideDates", "RideId", "dbo.Rides");
            DropIndex("dbo.RideDates", new[] { "RideId" });
        }
    }
}
