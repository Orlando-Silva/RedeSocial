#region --Using--
using DAL;
using Services.Interfaces;
#endregion

namespace Services
{
    public class WebApiService : Service, IWebApiService
    {
        #region --Atributos--
        private static UnidadeDeTrabalho UnidadeDeTrabalho { get { return BuscarUnidadeDeTrabalho(); } }
        #endregion

        #region --Construtor--
        public WebApiService()
        {

        }
        #endregion

        public object BuscarUsuario(int id)
        {
            var usuario = UnidadeDeTrabalho.Usuarios.Buscar(id);

            if(usuario != null)
            { 
                return new
                {
                    usuario.Nome,
                    usuario.DataDeNascimento,
                    usuario.Email,
                    usuario.Cidade
                };
            }
            else
            {
                return new
                {
                    error = "Usuário não encontrado"
                };
            }
        }

        public bool UsuarioEstaCadastrado(string email)
        {
            var usuario = UnidadeDeTrabalho.Usuarios.Buscar(_ => _.Email == email);

            return usuario != null;
        }
    }
}
