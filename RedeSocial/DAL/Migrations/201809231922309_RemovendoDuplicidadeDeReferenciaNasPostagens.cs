namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoDuplicidadeDeReferenciaNasPostagens : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Postagens", "AutorID", "dbo.Usuarios");
            AddForeignKey("dbo.Postagens", "AutorID", "dbo.Usuarios", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postagens", "AutorID", "dbo.Usuarios");
            AddForeignKey("dbo.Postagens", "AutorID", "dbo.Usuarios", "ID");
        }
    }
}
