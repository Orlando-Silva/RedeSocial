namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentarios", "AutorID", "dbo.Usuarios");
            AddForeignKey("dbo.Comentarios", "AutorID", "dbo.Usuarios", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "AutorID", "dbo.Usuarios");
            AddForeignKey("dbo.Comentarios", "AutorID", "dbo.Usuarios", "ID");
        }
    }
}
