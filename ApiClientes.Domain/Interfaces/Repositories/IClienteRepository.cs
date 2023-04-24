using ApiClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Interfaces.Repositories
{

    /// <summary>
    /// Interface de repositório para cliente
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Clientes>
    {
        Clientes GetByEmail(string email);
    }
}
