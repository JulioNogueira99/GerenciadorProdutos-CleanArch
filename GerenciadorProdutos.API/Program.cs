using GerenciadorProdutos.Application.Services;
using GerenciadorProdutos.Domain.Interfaces;
using GerenciadorProdutos.Infrastructure.Persistence;
using GerenciadorProdutos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Configurar o Banco de Dados (EF Core)
// Pega a string do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GerenciadorProdutosDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Injeção de Dependência (DI)
// "Sempre que alguém pedir IProductRepository, entregue ProductRepository"
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// "Sempre que alguém pedir IProductService, entregue ProductService"
builder.Services.AddScoped<IProductService, ProductService>();

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