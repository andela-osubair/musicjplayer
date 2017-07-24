namespace MusicJPlayer.MusicJPlayerContextMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FileDetails", newName: "FileDetail");
            RenameTable(name: "dbo.MusicInfoes", newName: "MusicInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MusicInfo", newName: "MusicInfoes");
            RenameTable(name: "dbo.FileDetail", newName: "FileDetails");
        }
    }
}
