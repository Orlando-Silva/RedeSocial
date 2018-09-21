#region --Using--
using Core.Entidades;
using Core.ViewModels;
#endregion

namespace Services.UsuarioServices.Módulos.Interfaces
{
    public interface IUsuarioOperacoesBasicas<T> where T : Usuario
    {
        T Adicionar(NovoUsuarioViewModel _usuario);
        T Inativar(int usuarioID);
        T Atualizar(PerfilViewModel usuario);
    }
}
