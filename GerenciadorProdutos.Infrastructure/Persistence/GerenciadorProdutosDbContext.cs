using GerenciadorProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorProdutos.Infrastructure.Persistence
{
    public class GerenciadorProdutosDbContext : DbContext
    {
        public GerenciadorProdutosDbContext(DbContextOptions<GerenciadorProdutosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}