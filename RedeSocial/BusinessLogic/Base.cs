#region --Using--
using DAL;
using DAL.Contexto;
#endregion

namespace BusinessLogic
{
    public class Base
    {
        protected static UnidadeDeTrabalho UnidadeDeTrabalho
        {
            get => UnidadeDeTrabalho is null ? new UnidadeDeTrabalho(new RedeSocialContexto()) : UnidadeDeTrabalho;
        }
    }
}
