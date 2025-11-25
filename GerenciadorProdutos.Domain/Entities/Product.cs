using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProdutos.Domain.Entities
{
    public class Product
    {
        public Product(string title, decimal price, string description)
        {
            // Validação básica no construtor (Fail Fast)
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("O título é obrigatório.");

            if (price < 0)
                throw new ArgumentException("O preço não pode ser negativo.");

            Title = title;
            Price = price;
            Description = description;
            IsActive = true;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; } // Private set: só o EF ou a própria classe altera
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Método de negócio: Atualizar preço
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Preço inválido");
            Price = newPrice;
        }

        // Método de negócio: Desativar produto (Soft Delete)
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
