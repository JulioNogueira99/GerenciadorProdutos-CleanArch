using GerenciadorProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorProdutos.Infrastructure.Persistence
{
    public class GerenciadorProdutosDbContext : DbContext
    {
        // Construtor recebendo as opções (Connection String vem daqui)
        public GerenciadorProdutosDbContext(DbContextOptions<GerenciadorProdutosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Essa linha mágica busca todas as classes que implementam IEntityTypeConfiguration 
            // neste Assembly (como a ProductConfiguration que criamos acima) e aplica.
            // Evita ter que ficar chamando "modelBuilder.ApplyConfiguration" uma por uma.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}