#region --Using--
using Core.Entidades;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace DAL.FluentAPI
{
    public class ComentarioConfiguracao : EntityTypeConfiguration<Comentario>
    {
        public ComentarioConfiguracao()
        {
            ToTable("Comentarios");

            Property(_ => _.Conteudo)
                    .HasMaxLength(600);

            HasRequired(_ => _.Autor)
                    .WithMany(_ => _.Comentarios)
                    .HasForeignKey(_ => _.AutorID)
                    .WillCascadeOnDelete(false);
        }
    }
}
