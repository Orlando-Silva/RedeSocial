#region --Using--
using Core.Entidades;
using Core.Enums;
using DAL;
using Services.Construtores;
using Services.Interfaces;
using System;
using System.Web;
#endregion

namespace Services
{
    public class FotoDePerfilService : Service, IFotoDePerfilService<FotoDePerfil>
    {

        #region --Atributos--
        private static UnidadeDeTrabalho UnidadeDeTrabalho { get { return BuscarUnidadeDeTrabalho(); } }
        #endregion

        #region --Construtor--
        public FotoDePerfilService()
        {

        }
        #endregion

        public FotoDePerfil Buscar(int usuarioID) => UnidadeDeTrabalho.FotosDePerfil.BuscarPorUsuario(usuarioID);

        public void SalvarNoServidor(HttpPostedFileBase arquivo, string diretorio) => arquivo.SaveAs(diretorio);

        public FotoDePerfil Inativar(int fotoDePerfilID)
        {
            var fotoDePerfil = UnidadeDeTrabalho.FotosDePerfil.Buscar(fotoDePerfilID);

            if (fotoDePerfil is FotoDePerfil)
            {
                fotoDePerfil = new ConstrutorFotoDePerfil(fotoDePerfil).ComStatus(Status.Inativo);
                UnidadeDeTrabalho.Encerrar();
            }

            return fotoDePerfil;
        }

        public FotoDePerfil Adicionar(HttpPostedFileBase arquivo, int usuarioID, string diretorio)
        {
            Validar(arquivo);
            var fotoDePerfil = new ConstrutorFotoDePerfil().Montar(arquivo,usuarioID, diretorio);
            SalvarNoServidor(arquivo, fotoDePerfil.Caminho);

            var usuario = UnidadeDeTrabalho.Usuarios.Buscar(usuarioID);

            foreach(var foto in usuario.Fotos)
            {
                Inativar(foto.ID);
            }

            new ConstrutorUsuario(usuario).ComFoto(fotoDePerfil);

            UnidadeDeTrabalho.Encerrar();
            return fotoDePerfil;
        }

        public void Validar(HttpPostedFileBase arquivo)
        {
            if(arquivo.ContentLength > 6000000)
            {
                throw new Exception("Tamanho máximo de arquivos: 6 MB");
            }
        }
    }
}
