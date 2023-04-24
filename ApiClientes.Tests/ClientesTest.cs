using ApiClientes.Application.Models;
using ApiClientes.Domain.Entities;
using ApiClientes.Tests.Helpers;
using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiClientes.Tests
{
    public class ClientesTest
    {
        private const string _endpoint = "/api/cliente";

        [Fact]
        public async Task<Clientes> Test_Post_Clientes_Returns_Created()
        {
            var faker = new Faker("pt_BR");

            var request = new ClientesPostModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = faker.Person.Phone,
                Cpf = faker.Person.Cpf()
            };

            var result = await TestsHelper.CreateClient.PostAsync(_endpoint, TestsHelper.CreateContent(request));
            result.StatusCode.Should().Be(HttpStatusCode.Created);

            var response = TestsHelper.ReadContent<ClientesResult>(result);
            response.Message.Should().Contain("Cliente cadastrado com sucesso");

            return response.Cliente;
        }

        [Fact]
        public async Task Test_Put_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var faker = new Faker("pt_BR");

            var request = new ClientesPutModel
            {
                IdCliente = cliente.IdCliente,
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = faker.Person.Phone,
                Cpf = faker.Person.Cpf()
            };

            var result = await TestsHelper.CreateClient.PutAsync(_endpoint, TestsHelper.CreateContent(request));
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<ClientesResult>(result);
            response.Message.Should().Contain("Cliente atualizado com sucesso");
        }

        [Fact]
        public async Task Test_Delete_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var result = await TestsHelper.CreateClient.DeleteAsync(_endpoint + "/" + cliente.IdCliente);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<ClientesResult>(result);
            response.Message.Should().Contain("Cliente excluído com sucesso");
        }

        [Fact]
        public async Task Test_GetAll_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var result = await TestsHelper.CreateClient.GetAsync(_endpoint);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var lista = TestsHelper.ReadContent<List<ClientesGetModel>>(result);
            lista.FirstOrDefault(c => c.IdCliente == cliente.IdCliente)
                .Should().NotBeNull();
        }

        [Fact]
        public async Task Test_GetById_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var result = await TestsHelper.CreateClient.GetAsync(_endpoint + "/" + cliente.IdCliente);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<ClientesGetModel>(result);
            response.IdCliente.Should().Be(cliente.IdCliente);
        }
    }

    //Classe para deserializar os dados que a API
    //retornar após uma operação com cliente
    public class ClientesResult
    {
        public string? Message { get; set; }
        public Clientes? Cliente { get; set; }
    }
}
