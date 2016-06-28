namespace TransmogDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransmogTransmogItems", "Transmog_ID", "dbo.Transmogs");
            DropForeignKey("dbo.TransmogTransmogItems", "TransmogItem_ID", "dbo.TransmogItems");
            DropIndex("dbo.TransmogTransmogItems", new[] { "Transmog_ID" });
            DropIndex("dbo.TransmogTransmogItems", new[] { "TransmogItem_ID" });
            CreateIndex("dbo.TransmogItems", "TransmogID");
            AddForeignKey("dbo.TransmogItems", "TransmogID", "dbo.Transmogs", "ID", cascadeDelete: true);
            DropTable("dbo.TransmogTransmogItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TransmogTransmogItems",
                c => new
                    {
                        Transmog_ID = c.Int(nullable: false),
                        TransmogItem_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transmog_ID, t.TransmogItem_ID });
            
            DropForeignKey("dbo.TransmogItems", "TransmogID", "dbo.Transmogs");
            DropIndex("dbo.TransmogItems", new[] { "TransmogID" });
            CreateIndex("dbo.TransmogTransmogItems", "TransmogItem_ID");
            CreateIndex("dbo.TransmogTransmogItems", "Transmog_ID");
            AddForeignKey("dbo.TransmogTransmogItems", "TransmogItem_ID", "dbo.TransmogItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TransmogTransmogItems", "Transmog_ID", "dbo.Transmogs", "ID", cascadeDelete: true);
        }
    }
}
