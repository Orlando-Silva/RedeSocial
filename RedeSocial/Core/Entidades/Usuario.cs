#region --Using--
using Core.Enums;
using System;
using System.Collections.Generic;
#endregion

namespace Core.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public string Complemento { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public string Descricao { get; set; }

        public DateTime Criado { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public Status Status { get; set; }

        public IList<FotoDePerfil> Fotos { get; set; }
    }
}
