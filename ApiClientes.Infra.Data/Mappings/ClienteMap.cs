using ApiClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            #region Chave primária

            builder.HasKey(c => c.IdCliente);

            #endregion

            #region Campos

            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Cpf).IsRequired();
            builder.Property(c => c.Telefone).IsRequired();
            

            #endregion

            #region Índices

            builder.HasIndex(c => c.Email).IsUnique();

            #endregion
        }
    }
}
