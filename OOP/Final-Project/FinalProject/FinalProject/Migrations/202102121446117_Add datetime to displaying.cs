namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddatetimetodisplaying : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Displayings", "DepartureTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Displayings", "DepartureTime");
        }
    }
}
