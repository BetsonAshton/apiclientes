using ApiClientes.Application.Models;
using ApiClientes.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Application.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap() 
        { 
            CreateMap<ClientesPostModel, Clientes>()
                 .AfterMap((src, dest) =>
                 {
                     dest.IdCliente = Guid.NewGuid();
                 });

            CreateMap<ClientesPutModel, Clientes>();

        }

    }
}
