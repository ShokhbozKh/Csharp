namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addstationnametolocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "StationName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "StationName");
        }
    }
}
