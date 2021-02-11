namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBusModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        IdBus = c.Int(nullable: false, identity: true),
                        BusName = c.String(),
                        SeatCount = c.Int(nullable: false),
                        HasWifi = c.Boolean(nullable: false),
                        HasAirCondition = c.Boolean(nullable: false),
                        BusTypeId = c.Int(nullable: false),
                        BusType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdBus);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Buses");
        }
    }
}
