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

            HasRequired(_ => _.Autor);

            HasMany(_ => _.Comentarios);
        }
    }
}
