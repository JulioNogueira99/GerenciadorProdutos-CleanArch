using GerenciadorProdutos.Domain.Entities;
using GerenciadorProdutos.Domain.Interfaces;
using GerenciadorProdutos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorProdutos.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GerenciadorProdutosDbContext _dbContext;

        public ProductRepository(GerenciadorProdutosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}