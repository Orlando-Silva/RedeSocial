#region --Using--
using Core.Entidades;
using Core.Enums;
using Core.Repositórios;
using DAL.Contexto;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DAL.Repositórios
{
    public class FotoDePerfilRepositorio : Repositorio<FotoDePerfil>, IFotoDePerfilRepositorio
    {
        public RedeSocialContexto RedeSocialContexto
        {
            get => Contexto as RedeSocialContexto;
        }

        public FotoDePerfilRepositorio(DbContext _contexto) : base(_contexto) { }

        public FotoDePerfil BuscarPorUsuario(int usuarioID) => RedeSocialContexto.Usuarios.Where(_ => _.ID == usuarioID).Select(_ => _.Fotos.Where(f => f.Status == Status.Ativo)) as FotoDePerfil;
    }
}
