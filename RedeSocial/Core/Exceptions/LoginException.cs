#region --Using--
using System;
#endregion

namespace Core.Exceptions
{
    public class LoginException : Exception
    {

        public LoginException(string mensagem) : base(mensagem)
        {

        }
    }
}
