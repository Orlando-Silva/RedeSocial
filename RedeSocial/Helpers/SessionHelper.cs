#region --Using--
using Newtonsoft.Json;
using System;
using System.Web;
#endregion

namespace Helpers
{
    public class SessionHelper
    {
        public static HttpSessionStateBase StoreInSession<T>(HttpSessionStateBase currentSession, T entidade) where T : class
        {
            if (entidade is default(T))
                throw new ArgumentNullException(message: $"O parâmetro não pode ser nulo.", paramName: nameof(entidade));

            var sessionObject = JsonConvert.SerializeObject(entidade);

            var encryptedObject = Seguranca.Encrypt(sessionObject);

            currentSession[nameof(T)] = encryptedObject;

            return currentSession;           
        }

        public static T GetSessionObject<T>(HttpSessionStateBase currentSession, IEntityValidator<T> Validator) where T : class
        {
            var encryptedEntity = currentSession[nameof(T)]?.ToString();

            if (encryptedEntity is null)
                return null;

            var decryptedEntity = Seguranca.Decrypt(encryptedEntity);

            var entityObject = JsonConvert.DeserializeObject<T>(decryptedEntity);

            return Validator.IsValid(entityObject) ? entityObject : null;         
        }
    }
}
