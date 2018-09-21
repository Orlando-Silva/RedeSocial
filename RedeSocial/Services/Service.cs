#region --Using--
using DAL;
using DAL.Contexto;
#endregion

namespace Services
{
    public class Service
    {
        #region --Atributos--
        private static readonly UnidadeDeTrabalho UnidadeDeTrabalho = new UnidadeDeTrabalho(new RedeSocialContexto());
        #endregion

        #region --Métodos--
        protected static UnidadeDeTrabalho BuscarUnidadeDeTrabalho() => UnidadeDeTrabalho ?? new UnidadeDeTrabalho(new RedeSocialContexto());
        #endregion
    }
}
