﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Application.Models
{
    public class ClientesGetModel
    {
        public Guid IdCliente { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Cpf { get; set; }

        public string? Telefone { get; set; }
    }
}
