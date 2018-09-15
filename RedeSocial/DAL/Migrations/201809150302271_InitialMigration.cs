namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(maxLength: 600),
                        Status = c.Int(nullable: false),
                        Criado = c.DateTime(nullable: false),
                        PostagemID = c.Int(nullable: false),
                        AutorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.AutorID)
                .ForeignKey("dbo.Postagens", t => t.PostagemID)
                .Index(t => t.PostagemID)
                .Index(t => t.AutorID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 128),
                        Email = c.String(maxLength: 64),
                        Login = c.String(maxLength: 64),
                        Senha = c.String(maxLength: 512),
                        Telefone = c.String(maxLength: 64),
                        Complemento = c.String(maxLength: 64),
                        Endereco = c.String(maxLength: 64),
                        Cidade = c.String(maxLength: 64),
                        Estado = c.String(maxLength: 64),
                        Pais = c.String(maxLength: 64),
                        Descricao = c.String(maxLength: 512),
                        Criado = c.DateTime(nullable: false),
                        DataDeNascimento = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FotosDePerfil",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 120),
                        Extensao = c.String(maxLength: 64),
                        Tamanho = c.Decimal(nullable: false, precision: 18, scale: 9),
                        Caminho = c.String(maxLength: 256),
                        Hash = c.String(maxLength: 512),
                        Status = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Postagens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Corpo = c.String(),
                        Status = c.Int(nullable: false),
                        Criado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(),
                        AutorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.AutorID)
                .Index(t => t.AutorID);
            
            CreateTable(
                "dbo.Amizades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SolicitanteID = c.Int(nullable: false),
                        ConvidadoID = c.Int(nullable: false),
                        Criado = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.ConvidadoID)
                .ForeignKey("dbo.Usuarios", t => t.SolicitanteID)
                .Index(t => t.SolicitanteID)
                .Index(t => t.ConvidadoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Amizades", "SolicitanteID", "dbo.Usuarios");
            DropForeignKey("dbo.Amizades", "ConvidadoID", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "PostagemID", "dbo.Postagens");
            DropForeignKey("dbo.Comentarios", "AutorID", "dbo.Usuarios");
            DropForeignKey("dbo.Postagens", "AutorID", "dbo.Usuarios");
            DropForeignKey("dbo.FotosDePerfil", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Amizades", new[] { "ConvidadoID" });
            DropIndex("dbo.Amizades", new[] { "SolicitanteID" });
            DropIndex("dbo.Postagens", new[] { "AutorID" });
            DropIndex("dbo.FotosDePerfil", new[] { "UsuarioID" });
            DropIndex("dbo.Comentarios", new[] { "AutorID" });
            DropIndex("dbo.Comentarios", new[] { "PostagemID" });
            DropTable("dbo.Amizades");
            DropTable("dbo.Postagens");
            DropTable("dbo.FotosDePerfil");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Comentarios");
        }
    }
}
