namespace ppedv.Pillenpresse.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wirkstoffs", "Verfallsdatum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wirkstoffs", "Verfallsdatum");
        }
    }
}
