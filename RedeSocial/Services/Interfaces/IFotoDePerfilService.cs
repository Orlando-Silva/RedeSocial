#region --Using--
using Core.Entidades;
using System.Web;
#endregion

namespace Services.Interfaces
{
    public interface IFotoDePerfilService<T> where T : FotoDePerfil 
    {
        T Adicionar(HttpPostedFileBase arquivo, int usuarioID, string diretorio);

        T Buscar(int usuarioID);

        T Inativar(int fotoDePerfilID);

        void SalvarNoServidor(HttpPostedFileBase arquivo, string diretorio);

        void Validar(HttpPostedFileBase arquivo);
    }
}
