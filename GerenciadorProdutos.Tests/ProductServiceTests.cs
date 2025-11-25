using GerenciadorProdutos.Application.Models;
using GerenciadorProdutos.Application.Services;
using GerenciadorProdutos.Domain.Entities;
using GerenciadorProdutos.Domain.Interfaces;
using Moq;
using Xunit;

namespace GerenciadorProdutos.Tests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Valida se o produto é persistido no repositório quando os dados de entrada são válidos.
        /// </summary>
        [Fact]
        public async Task Create_QuandoDadosValidos_DeveSalvarNoBanco()
        {
            // Arrange
            var repositorioMock = new Mock<IProductRepository>();

            var service = new ProductService(repositorioMock.Object);

            var inputModel = new CreateProductInputModel
            {
                Title = "Mouse Gamer",
                Price = 100,
                Description = "Mouse rápido"
            };

            // Act
            var resultadoId = await service.Create(inputModel);

            //Assert
            Assert.True(resultadoId >= 0);
            repositorioMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}