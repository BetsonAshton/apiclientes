using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Entities
{
    public class Clientes
    {
        private Guid _idClientes;

        private string? _nome;

        private string? _email;

        private string? _cpf;

        private string? _Telefone;

        public Guid IdCliente { get => _idClientes; set => _idClientes = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public string? Telefone { get => _Telefone; set => _Telefone = value; }
    }
}
