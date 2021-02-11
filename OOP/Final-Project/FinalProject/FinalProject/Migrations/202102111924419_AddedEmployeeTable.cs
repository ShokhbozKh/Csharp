namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "HireDate", c => c.DateTime());
            AddColumn("dbo.Users", "Discount1", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "Discount1");
            DropColumn("dbo.Users", "HireDate");
        }
    }
}
