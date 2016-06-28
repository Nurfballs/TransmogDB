namespace TransmogDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transmogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Realm = c.String(nullable: false),
                        Race = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transmogs");
        }
    }
}
