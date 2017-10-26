namespace VendingMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Machines", "Name");
        }
    }
}
