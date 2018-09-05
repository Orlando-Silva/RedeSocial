#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Data.Entity;
#endregion

namespace DAL.Repositórios
{
    public class FotoDePerfilRepositorio : Repositorio<FotoDePerfil>, IFotoDePerfilRepositorio
    {
        public FotoDePerfilRepositorio(DbContext _contexto) : base(_contexto) { }
    }
}
