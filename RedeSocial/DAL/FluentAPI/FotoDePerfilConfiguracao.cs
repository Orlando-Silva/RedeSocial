#region --Using--
using Core.Entidades;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace DAL.FluentAPI
{
    public class FotoDePerfilConfiguracao : EntityTypeConfiguration<FotoDePerfil>
    {
        public FotoDePerfilConfiguracao()
        {
            ToTable("FotosDePerfil");

            Property(_ => _.Nome)
                    .HasMaxLength(120);

            Property(_ => _.Extensao)
                    .HasMaxLength(64);

            Property(_ => _.Tamanho)
                    .HasPrecision(18,9);

            Property(_ => _.Caminho)
                    .HasMaxLength(256);

            Property(_ => _.Hash)
                    .HasMaxLength(512);

            HasRequired(_ => _.Usuario)
                    .WithMany(_ => _.Fotos)
                    .HasForeignKey(_ => _.UsuarioID)
                    .WillCascadeOnDelete(false);
        }
    }
}
