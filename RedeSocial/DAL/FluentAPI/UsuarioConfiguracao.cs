#region --Using--
using Core.Entidades;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace DAL.FluentAPI
{
    public class UsuarioConfiguracao : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguracao()
        {
            ToTable("Usuarios");

            Property(_ => _.Nome)
                .HasMaxLength(128);

            Property(_ => _.Login)
                .HasMaxLength(64);

            Property(_ => _.Telefone)
                .HasMaxLength(64);

            Property(_ => _.Email)
                .HasMaxLength(64);

            Property(_ => _.Senha)
                .HasMaxLength(512);

            Property(_ => _.Complemento)
                .IsOptional()
                .HasMaxLength(64);

            Property(_ => _.Endereco)
               .HasMaxLength(64);

            Property(_ => _.Cidade)
               .HasMaxLength(64);

            Property(_ => _.Estado)
               .HasMaxLength(64);

            Property(_ => _.Pais)
               .HasMaxLength(64);

            Property(_ => _.Descricao)
               .IsOptional()
               .HasMaxLength(512);

            HasMany(_ => _.Amigos)
                .WithMany(_ => _.Amigos)
                .Map(m =>
                {
                    m.MapLeftKey("PrimeiroUsuario");
                    m.MapRightKey("SegundoUsuario");
                    m.ToTable("Amizades");
                });

            HasMany(_ => _.Fotos)
                .WithRequired(_ => _.Usuario)
                .HasForeignKey(_ => _.Usuario.ID);

            HasMany(_ => _.Postagens)
                .WithRequired(_ => _.Autor)
                .HasForeignKey(_ => _.Autor.ID);

            HasMany(_ => _.Comentarios)
                .WithRequired(_ => _.Autor)
                .HasForeignKey(_ => _.Autor.ID);
        }
    }
}
