namespace TP5Samourai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ArtMartials", name: "Arts Martiaux maitrisés", newName: "Nom");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.ArtMartials", name: "Nom", newName: "Arts Martiaux maitrisés");
        }
    }
}
