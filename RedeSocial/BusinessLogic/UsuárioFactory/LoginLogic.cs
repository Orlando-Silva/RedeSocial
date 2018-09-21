#region --Using--
using Helpers;
using Core.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace BusinessLogic.Usuario
{
    public class LoginLogic : Alicerce, IValidadorDeSessao<Usuario>
    {
    }
}
