#region --Using--
using Core.Entidades;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace DAL.FluentAPI
{
    public class PostagemConfiguracao : EntityTypeConfiguration<Postagem>
    {
        public PostagemConfiguracao()
        {
            ToTable("Postagens");

            Property(_ => _.Corpo)
                .HasMaxLength(5000);

            HasRequired(_ => _.Autor)
                .WithMany(_ => _.Postagens)
                .HasForeignKey(_ => _.Autor.ID);

            HasMany(_ => _.Comentarios)
                .WithRequired(_ => _.Postagem)
                .HasForeignKey(_ => _.Postagem.ID);
        }
    }
}
