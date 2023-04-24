using ApiClientes.Domain.Entities;
using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Cliente
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public ClienteRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Clientes GetByEmail(string email)
        {
            return _sqlServerContext.Cliente
                .AsNoTracking()
                .FirstOrDefault(c => c.Email.Equals(email));
        }

        public void Create(Clientes entity)
        {
            _sqlServerContext.Cliente.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Clientes entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Clientes entity)
        {
            _sqlServerContext.Cliente.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public List<Clientes> GetAll()
        {
            return _sqlServerContext.Cliente
                .ToList();
        }

        public Clientes GetById(Guid id)
        {
            return _sqlServerContext.Cliente
               .AsNoTracking()
               .FirstOrDefault(c => c.IdCliente == id);
        }
    }
}
