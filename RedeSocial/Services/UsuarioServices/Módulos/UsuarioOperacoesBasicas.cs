#region --Using--
using Core.Entidades;
using Core.ViewModels;
using Services.Estruturas;
using Services.UsuarioServices.Módulos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Services.UsuarioServices.Interfaces
{
    public class UsuarioOperacoesBasicas : Service, IUsuarioOperacoesBasicas<Usuario>
    {
        public Usuario Adicionar(NovoUsuarioViewModel _usuario)
        {
            var usuario = Montar(_usuario);

            var UnidadeDeTrabalho = BuscarUnidadeDeTrabalho();
            UnidadeDeTrabalho.Usuarios.Adicionar(usuario);
            UnidadeDeTrabalho.Encerrar();
            SessionHelper.StoreInSession(sessionAtual, usuario);
        }

        public Usuario Atualizar(PerfilViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Inativar(int usuarioID)
        {
            throw new NotImplementedException();
        }
    }
}
