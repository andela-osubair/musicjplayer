namespace MusicJPlayer.MusicJPlayerContextMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        MusicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MusicInfoes", t => t.MusicInfoId, cascadeDelete: true)
                .Index(t => t.MusicInfoId);
            
            CreateTable(
                "dbo.MusicInfoes",
                c => new
                    {
                        MusicInfoId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Artist = c.String(nullable: false, maxLength: 100),
                        CoverArt = c.String(),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.MusicInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDetails", "MusicInfoId", "dbo.MusicInfoes");
            DropIndex("dbo.FileDetails", new[] { "MusicInfoId" });
            DropTable("dbo.MusicInfoes");
            DropTable("dbo.FileDetails");
        }
    }
}
