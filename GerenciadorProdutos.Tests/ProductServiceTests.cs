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
        [Fact] // [Fact] avisa o xUnit: "Ei, isso aqui é um teste, rode ele!"
        public async Task Create_QuandoDadosValidos_DeveSalvarNoBanco()
        {
            // --- 1. ARRANGE (Preparação) ---
            // Aqui a gente prepara o cenário.

            // Criamos o "Dublê" do repositório. Ele não salva nada de verdade.
            var repositorioMock = new Mock<IProductRepository>();

            // Criamos o Service (a peça que queremos testar), entregando o dublê pra ele.
            var service = new ProductService(repositorioMock.Object);

            // Criamos o dado de entrada (InputModel)
            var inputModel = new CreateProductInputModel
            {
                Title = "Mouse Gamer",
                Price = 100,
                Description = "Mouse rápido"
            };

            // --- 2. ACT (Ação) ---
            // É aqui que chamamos o método que queremos testar.
            // Executamos a ação como se fossemos a API chamando o serviço.
            var resultadoId = await service.Create(inputModel);

            // --- 3. ASSERT (Verificação) ---
            // Aqui conferimos se aconteceu o que deveria acontecer.

            // Verifica se o ID retornado é maior ou igual a 0 (ou seja, não deu erro)
            Assert.True(resultadoId >= 0);

            // A PARTE MAIS IMPORTANTE:
            // Perguntamos para o Dublê: "Ei, o método AddAsync foi chamado exatamente 1 vez?"
            // Se o Service tiver esquecido de chamar o repositório, o teste falha aqui.
            repositorioMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}