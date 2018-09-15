#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Data.Entity;
#endregion

namespace DAL.Repositórios
{
    public class AmizadeRepositorio : Repositorio<Amizades>, IAmizadeRepositorio
    {
        public AmizadeRepositorio(DbContext _contexto) : base(_contexto) { }
    }
}
