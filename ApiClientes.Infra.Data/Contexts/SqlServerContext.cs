using ApiClientes.Domain.Entities;
using ApiClientes.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Contexts
{
    public class SqlServerContext:DbContext
    {
        //método para conexão com o banco de dados ou InMemory
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BD_ApiClientes");
        }

        //método para adicionarmos as classes de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }

        //Propriedade DbSet para cada entidade (CRUD)
        public DbSet<Clientes> Cliente { get; set; }
    }

}

