using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Models
{
    public class AlterarSenhaModel
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Digite a senha atual do usuario")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite uma nova senha ")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Digite a senha atual do usuario")]
        [Compare("NovaSenha", ErrorMessage ="As senhas precisão ser iguais")]
        public string ConfirmarNovaSenha { get; set; }

    }
}
