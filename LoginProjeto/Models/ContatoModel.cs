using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o Nome do Contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Digite o Email")]
        [EmailAddress(ErrorMessage ="Digite um Email Valido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite o Celular")]
        [Phone(ErrorMessage ="Digite um Celular Valido")]
        public string Celular { get; set; }
    }
}
