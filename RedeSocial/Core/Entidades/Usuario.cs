﻿#region --Using--
using Core.Enums;
using System.Collections.Generic;
#endregion

namespace Core.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }

        public string PrimeiroNome { get; set; }

        public string SegundoNome { get; set; }

        public string UltimoNome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Rua { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }

        public IList<Usuario> Amigos { get; set; }

        public IList<FotoDePerfil> Fotos { get; set; }
    }
}
