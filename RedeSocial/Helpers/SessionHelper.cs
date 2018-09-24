#region --Using--
using Helpers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Web;
#endregion

namespace Helpers
{
    public class SessionHelper
    {
        public static void AdicionarNaSessao<T>(HttpSessionStateBase sessao, T entidade) where T : class
        {
            if (entidade is default(T))
                throw new ArgumentNullException(message: $"O parâmetro não pode ser nulo.", paramName: nameof(entidade));

            var objeto = JsonConvert.SerializeObject(entidade);

            var objetoEncriptado = Seguranca.Encriptar(objeto);

            sessao[nameof(T)] = objetoEncriptado;
        }

        public static T BuscarNaSessao<T>(HttpSessionStateBase sessao, IValidadorDeSessao<T> Validador) where T : class
        {

            if (sessao[nameof(T)]?.ToString() == null)
                return null;

            var objeto = sessao[nameof(T)]?.ToString();

            var objecto = Seguranca.Decriptar(objeto);

            var entidade = JsonConvert.DeserializeObject<T>(objecto);

            return Validador.ValidarSessao(entidade) ? entidade : null;         
        }
    }
}
