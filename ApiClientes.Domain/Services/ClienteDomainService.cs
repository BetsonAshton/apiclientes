using ApiClientes.Domain.Entities;
using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Services
{
    /// <summary>
    /// Classe de serviços de dominio para cliente
    /// </summary>
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Create(Clientes entity)
        {
            #region EMAIL deve ser Único para cada cliente
            if (_clienteRepository.GetByEmail(entity.Email) != null)
                throw new ArgumentException($"O email '{entity.Email}', já está cadastrado para outro cliente.");
            #endregion
            
            entity.IdCliente = Guid.NewGuid();
            entity.Email = entity.Email;
            entity.Cpf= entity.Cpf;
            entity.Telefone = entity.Telefone;

            _clienteRepository.Create(entity);
        }

        public void Update(Clientes entity)
        {
            #region O Cliente deve existir no banco de dados

            var cliente = _clienteRepository.GetById(entity.IdCliente);
            if (cliente == null)
                throw new ArgumentException($"O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Email deve ser único para cada cliente

            var clienteByEmail = _clienteRepository.GetByEmail(entity.Email);
            if (clienteByEmail != null && clienteByEmail.IdCliente != entity.IdCliente)
                throw new ArgumentException($"O Email '{entity.Email}', já está cadastrado para outro cliente.");

            #endregion

            _clienteRepository.Update(entity);
        }

        public void Delete(Guid id)
        {
            #region O Cliente deve existir no banco de dados

            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new ArgumentException($"O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            _clienteRepository.Delete(cliente);
        }

        public List<Clientes> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Clientes GetById(Guid id)
        {
            #region O Cliente deve existir no banco de dados

            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new ArgumentException($"O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            return cliente;
        }
    }
}
