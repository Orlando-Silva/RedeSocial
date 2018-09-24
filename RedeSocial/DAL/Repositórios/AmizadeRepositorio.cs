#region --Using--
using Core.Entidades;
using Core.Enums;
using Core.Repositórios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DAL.Repositórios
{
    public class AmizadeRepositorio : Repositorio<Amizade>, IAmizadeRepositorio
    {
        public AmizadeRepositorio(DbContext _contexto) : base(_contexto) { }

        public List<Usuario> BuscarAmigos(int usuarioID, Status status)
        {
            return Entidades.Where(_ => _.Solicitante.ID == usuarioID && _.Status == status).Select(_ => _.Convidado).ToList();
        }

        public List<Amizade> BuscarAmizades(int usuarioID, Status status)
        {
            return Entidades.Include(_ => _.Convidado).Include(_ => _.Convidado.Fotos).Include(_ => _.Solicitante).Include(_ => _.Solicitante.Fotos).Where(_ => _.Solicitante.ID == usuarioID && _.Status == status).ToList();
        }
    }
}
