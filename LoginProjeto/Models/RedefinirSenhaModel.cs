using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Models
{
    public class RedefinirSenhaModel
    {
        [EmailAddress(ErrorMessage = "Digite um Email Valido")]
        [Required(ErrorMessage = "Digite o Email para Login")]
        public string Email { get; set; }
    }
}
