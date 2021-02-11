namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CustomerTypeId", c => c.Int());
            AddColumn("dbo.Users", "CustomerType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CustomerType");
            DropColumn("dbo.Users", "CustomerTypeId");
        }
    }
}
