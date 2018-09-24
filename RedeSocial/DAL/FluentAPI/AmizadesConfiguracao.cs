#region --Using--
using Core.Entidades;
using System.Data.Entity.ModelConfiguration;
#endregion

namespace DAL.FluentAPI
{
    public class AmizadesConfiguracao : EntityTypeConfiguration<Amizade>
    {
        public AmizadesConfiguracao()
        {
            ToTable("Amizades");
        }
    }
}
