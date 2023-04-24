using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Domain.Interfaces.Services;
using ApiClientes.Domain.Services;
using ApiClientes.Infra.Data.Contexts;
using ApiClientes.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configurando as inje��es de depend�ncia

builder.Services.AddTransient<IClienteDomainService, ClienteDomainService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<SqlServerContext>();

#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


#region Habilitando as configura��es de CORS

builder.Services.AddCors(
        s => s.AddPolicy("DefaultPolicy", builder =>
        {
            builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                .AllowAnyMethod() //qualquer m�todo (POST, PUT, DELETE, GET)
                .AllowAnyHeader(); //qualquer informa��o de cabe�alho
        })
);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();




app.Run();

public partial class Program { }
