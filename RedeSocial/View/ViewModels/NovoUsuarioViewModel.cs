#region --Using--
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace View.ViewModels
{
    public class NovoUsuarioViewModel
    {

        public string Login { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string ConfirmacaoSenha { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public string Complemento { get; set; }

    }
}