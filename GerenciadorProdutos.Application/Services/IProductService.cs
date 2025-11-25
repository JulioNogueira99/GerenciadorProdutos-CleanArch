using GerenciadorProdutos.Application.Models;

namespace GerenciadorProdutos.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task<int> Create(CreateProductInputModel model);
    }
}