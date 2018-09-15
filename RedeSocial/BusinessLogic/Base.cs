﻿#region --Using--
using DAL;
using DAL.Contexto;
#endregion

namespace BusinessLogic
{
    public class Base
    {
        private readonly static UnidadeDeTrabalho UnidadeDeTrabalho = new UnidadeDeTrabalho(new RedeSocialContexto());

        protected static UnidadeDeTrabalho BuscarUnidadeDeTrabalho() => UnidadeDeTrabalho ?? new UnidadeDeTrabalho(new RedeSocialContexto());



    }
}
