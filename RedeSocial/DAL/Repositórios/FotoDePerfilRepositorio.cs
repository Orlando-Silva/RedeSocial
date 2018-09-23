#region --Using--
using Core.Entidades;
using Core.Enums;
using Core.Repositórios;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DAL.Repositórios
{
    public class FotoDePerfilRepositorio : Repositorio<FotoDePerfil>, IFotoDePerfilRepositorio
    {
        public FotoDePerfilRepositorio(DbContext _contexto) : base(_contexto) { }

        public FotoDePerfil BuscarPorUsuario(int usuarioID) => Entidades.FirstOrDefault(_ => _.Usuario.ID == usuarioID && _.Status == Status.Ativo);
    }
}
