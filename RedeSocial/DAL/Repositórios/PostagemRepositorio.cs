﻿#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DAL.Repositórios
{
    public class PostagemRepositorio : Repositorio<Postagem>, IPostagemRepositorio
    {
        #region --Construtor--
        public PostagemRepositorio(DbContext _contexto) : base(_contexto) { }
        #endregion

        public IEnumerable<Postagem> BuscarPorUsuario(int usuarioID) => Entidades.Include(_ => _.Autor.Fotos).Include(_ => _.Comentarios).Where(_ => _.Autor.ID == usuarioID);

        public IEnumerable<Postagem> Buscar(int usuarioID, List<int> amigos)
        {
            return Entidades.Include(_ => _.Autor.Fotos).Include(_ => _.Comentarios).Where(_ => _.Autor.ID == usuarioID  || amigos.Any(a => _.Autor.ID == a)).ToList();

        }
    }
}
