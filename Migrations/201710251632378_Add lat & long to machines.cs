namespace VendingMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlatlongtomachines : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "Lat", c => c.String());
            AddColumn("dbo.Machines", "Long", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Machines", "Long");
            DropColumn("dbo.Machines", "Lat");
        }
    }
}
