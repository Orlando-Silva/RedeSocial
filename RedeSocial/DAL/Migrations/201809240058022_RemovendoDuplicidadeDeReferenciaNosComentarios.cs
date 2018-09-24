namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoDuplicidadeDeReferenciaNosComentarios : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comentarios", new[] { "PostagemID" });
            RenameColumn(table: "dbo.Comentarios", name: "PostagemID", newName: "Postagem_ID");
            AlterColumn("dbo.Comentarios", "Postagem_ID", c => c.Int());
            CreateIndex("dbo.Comentarios", "Postagem_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comentarios", new[] { "Postagem_ID" });
            AlterColumn("dbo.Comentarios", "Postagem_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comentarios", name: "Postagem_ID", newName: "PostagemID");
            CreateIndex("dbo.Comentarios", "PostagemID");
        }
    }
}
