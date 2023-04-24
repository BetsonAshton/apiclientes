using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Application.Models
{
    public class ClientesPostModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do Cliente.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Por favor, informe o cpf cliente.")]
        public string? Cpf{ get; set; }


        [Required(ErrorMessage = "Por favor, informe o telefone do cliente.")]
        public string? Telefone { get; set; }
    }
}
