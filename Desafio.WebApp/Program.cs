using Desafio.WebApp.Domain.Pedidos.Repositories;
using Desafio.WebApp.Shared.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;
using Desafio.WebApp.Domain.Produtos.DomainService;
using Desafio.WebApp.Domain.Produtos.DomainService.Contracts;
using Desafio.WebApp.Domain.Produtos.Repository;
using Desafio.WebApp.Domain.Produtos.Repository.Contracts;
using Desafio.WebApp.Shared.Services.Contratos;
using Desafio.WebApp.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContextDesafio>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoDomainService, ProdutoDomainService>();
builder.Services.AddScoped<IEmailService, MockEmailService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
