namespace ppedv.Pillenpresse.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ICD10 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wirkstoffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MengeProEinheit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WirkstoffSymptoms",
                c => new
                    {
                        Wirkstoff_Id = c.Int(nullable: false),
                        Symptom_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wirkstoff_Id, t.Symptom_Id })
                .ForeignKey("dbo.Wirkstoffs", t => t.Wirkstoff_Id, cascadeDelete: true)
                .ForeignKey("dbo.Symptoms", t => t.Symptom_Id, cascadeDelete: true)
                .Index(t => t.Wirkstoff_Id)
                .Index(t => t.Symptom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WirkstoffSymptoms", "Symptom_Id", "dbo.Symptoms");
            DropForeignKey("dbo.WirkstoffSymptoms", "Wirkstoff_Id", "dbo.Wirkstoffs");
            DropIndex("dbo.WirkstoffSymptoms", new[] { "Symptom_Id" });
            DropIndex("dbo.WirkstoffSymptoms", new[] { "Wirkstoff_Id" });
            DropTable("dbo.WirkstoffSymptoms");
            DropTable("dbo.Wirkstoffs");
            DropTable("dbo.Symptoms");
        }
    }
}
