using GerenciadorProdutos.Application.Models;
using GerenciadorProdutos.Domain.Entities;
using GerenciadorProdutos.Domain.Interfaces;

namespace GerenciadorProdutos.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var products = await _repository.GetAllAsync();

            return products
                .Select(p => new ProductViewModel(p.Id, p.Title, p.Price))
                .ToList();
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null) return null;

            return new ProductViewModel(product.Id, product.Title, product.Price);
        }

        public async Task<int> Create(CreateProductInputModel model)
        {
            var product = new Product(model.Title, model.Price, model.Description);

            await _repository.AddAsync(product);

            return product.Id;
        }
    }
}