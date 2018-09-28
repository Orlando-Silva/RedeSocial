#region --Using--
using Core.Entidades;
using DAL.FluentAPI;
using System.Data.Entity;
#endregion

namespace DAL.Contexto
{
    public class RedeSocialContexto : DbContext
    {
        #region --Atributos--
        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<FotoDePerfil> FotosDePerfil { get; set; }

        public DbSet<Postagem> Postagens { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        #region --Construtor--
        public RedeSocialContexto() : base("name=ConnectionStringlocalhost")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region --Override--
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ComentarioConfiguracao());
            modelBuilder.Configurations.Add(new FotoDePerfilConfiguracao());
            modelBuilder.Configurations.Add(new PostagemConfiguracao());
            modelBuilder.Configurations.Add(new UsuarioConfiguracao());
            modelBuilder.Configurations.Add(new AmizadesConfiguracao());
        }
        #endregion
    }
}
