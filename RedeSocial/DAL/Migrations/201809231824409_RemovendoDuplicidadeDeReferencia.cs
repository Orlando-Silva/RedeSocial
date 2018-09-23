namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoDuplicidadeDeReferencia : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FotosDePerfil", new[] { "UsuarioID" });
            RenameColumn(table: "dbo.FotosDePerfil", name: "UsuarioID", newName: "Usuario_ID");
            AlterColumn("dbo.FotosDePerfil", "Usuario_ID", c => c.Int());
            CreateIndex("dbo.FotosDePerfil", "Usuario_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FotosDePerfil", new[] { "Usuario_ID" });
            AlterColumn("dbo.FotosDePerfil", "Usuario_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FotosDePerfil", name: "Usuario_ID", newName: "UsuarioID");
            CreateIndex("dbo.FotosDePerfil", "UsuarioID");
        }
    }
}
