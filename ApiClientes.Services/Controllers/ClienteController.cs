using ApiClientes.Application.Models;
using ApiClientes.Domain.Entities;
using ApiClientes.Domain.Interfaces.Services;
using ApiClientes.Infra.Data.Repositories;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteDomainService _clienteDomainService;

        public ClienteController(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        [HttpPost]
        public IActionResult Post(ClientesPostModel model)
        {
            try
            {
                var cliente = new Clientes
                {
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Email = model.Email,
                    Telefone = model.Telefone
                };

                _clienteDomainService.Create(cliente);

                //HTTP 201 -> (CREATED)
                return StatusCode(201, new { message = "Cliente cadastrado com sucesso", cliente });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }


       
        [HttpPut]
        public IActionResult Put(ClientesPutModel model)
        {
            try
            {
                var cliente = new Clientes
                {
                    IdCliente = model.IdCliente,
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Email = model.Email,
                    Telefone = model.Telefone
                };

                _clienteDomainService.Update(cliente);

                //HTTP 200 -> (OK)
                return StatusCode(200, new { message = "Cliente atualizado com sucesso", cliente });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                

                _clienteDomainService.Delete(id);

                //HTTP 200 -> (OK)
                return StatusCode(200, new { message = "Cliente excluído com sucesso" });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(List<ClientesGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ClientesGetModel>();

                foreach (var item in _clienteDomainService.GetAll())
                {
                    lista.Add(new ClientesGetModel
                    {
                        IdCliente = item.IdCliente,
                        Nome = item.Nome,
                        Cpf = item.Cpf,
                        Email = item.Email,
                        Telefone = item.Telefone
                    });
                }

                //HTTP 200 -> (OK)
                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientesGetModel), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var cliente = _clienteDomainService.GetById(id);

                var response = new ClientesGetModel
                {
                    IdCliente = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                };

                //HTTP 200 -> (OK)
                return StatusCode(200, response);
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }


    }
}
