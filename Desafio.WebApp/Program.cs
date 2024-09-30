using Desafio.WebApp.Domain.Pedidos.Repositories.Contratos;
using Desafio.WebApp.Domain.Pedidos.Repositories;
using Desafio.WebApp.Shared.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Desafio.WebApp.Shared.Services.Contratos;
using Desafio.WebApp.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContextDesafio>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DesafioDb")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
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
