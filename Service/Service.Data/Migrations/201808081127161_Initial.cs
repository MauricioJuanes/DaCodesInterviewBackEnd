namespace Service.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.url_infos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        original_url = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
                        abreviation = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        added = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.url_infos");
        }
    }
}
