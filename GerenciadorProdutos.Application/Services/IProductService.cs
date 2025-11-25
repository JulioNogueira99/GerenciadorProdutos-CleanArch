using GerenciadorProdutos.Application.Models;

namespace GerenciadorProdutos.Application.Services
{
    public interface IProductService
    {
        // Note que devolvemos ViewModels, não Entidades!
        Task<List<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);

        // Recebemos InputModel para criar
        Task<int> Create(CreateProductInputModel model);
    }
}