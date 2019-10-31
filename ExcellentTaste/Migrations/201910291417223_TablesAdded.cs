namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Table", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Table");
        }
    }
}
