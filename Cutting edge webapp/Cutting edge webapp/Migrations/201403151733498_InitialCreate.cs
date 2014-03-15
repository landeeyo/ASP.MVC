namespace Cutting_edge_webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Country", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Street",
                c => new
                    {
                        StreetID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StreetID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Street", new[] { "CityID" });
            DropIndex("dbo.City", new[] { "CountryID" });
            DropForeignKey("dbo.Street", "CityID", "dbo.City");
            DropForeignKey("dbo.City", "CountryID", "dbo.Country");
            DropTable("dbo.Street");
            DropTable("dbo.City");
            DropTable("dbo.Country");
        }
    }
}
