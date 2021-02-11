namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddiscountreasonbusbustypesmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountReasons",
                c => new
                    {
                        IdDiscountReason = c.Int(nullable: false, identity: true),
                        DiscountName = c.String(),
                    })
                .PrimaryKey(t => t.IdDiscountReason);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        IdSeat = c.Int(nullable: false, identity: true),
                        Column = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        IsAtWindow = c.Boolean(nullable: false),
                        BusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeat);
            
            AddColumn("dbo.Buses", "DriverId", c => c.Int(nullable: false));
            AddColumn("dbo.Buses", "Driver_IdDriver", c => c.Int());
            CreateIndex("dbo.Buses", "Driver_IdDriver");
            AddForeignKey("dbo.Buses", "Driver_IdDriver", "dbo.Drivers", "IdDriver");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buses", "Driver_IdDriver", "dbo.Drivers");
            DropIndex("dbo.Buses", new[] { "Driver_IdDriver" });
            DropColumn("dbo.Buses", "Driver_IdDriver");
            DropColumn("dbo.Buses", "DriverId");
            DropTable("dbo.Seats");
            DropTable("dbo.DiscountReasons");
        }
    }
}
